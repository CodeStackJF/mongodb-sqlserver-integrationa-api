using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using MongoDB.Application.Exceptions;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoDB.Api.Middleware;
public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Infrastructure.Wrappers.Response();

            switch (error)
            {
                case CustomValidationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.ValidationErrors = e.Errors;
                    break;
                case MongoException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ValidationException e:
                    response.StatusCode = 400;
                    responseModel.Message = e.Message;
                    break;
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = e.Message;
                    break;
                case AuthenticationException e:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    responseModel.Message = e.Message;
                    break;
                case HttpRequestException e:
                    response.StatusCode = 400;
                    responseModel.Message = e.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Message = error.Message + error.InnerException;
                    break;
            }
            var result = JsonConvert.SerializeObject(responseModel);
            return response.WriteAsync(result);
        }
    }