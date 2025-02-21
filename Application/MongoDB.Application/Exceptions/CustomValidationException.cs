namespace MongoDB.Application.Exceptions;

public class CustomValidationException : Exception
    {
        public Dictionary<string, List<string>> Errors { get; } = new Dictionary<string, List<string>>();

        public CustomValidationException() : base("Se han producido errores de validación.")
        { 

        }

        public CustomValidationException(string property, string message)
        {
            Errors.Add(property, new List<string>(){message});
        }
    }