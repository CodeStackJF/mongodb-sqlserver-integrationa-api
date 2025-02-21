using Microsoft.AspNetCore.Mvc;
using MongoDB.Application.Exceptions;
using MongoDB.Domain.Mongo.Entities;
using MongoDB.Domain.Interfaces;

namespace MongoDB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository productRepository;
        public ProductsController(IProductsRepository _IProductsRepository)
        {
            productRepository = _IProductsRepository;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await productRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] productsCollection product)
        {
            if(await productRepository.Exists(product.id_product))
            {
                throw new HttpRequestException("Ya existe este id.");
            }
            var created = await productRepository.Save(product);
            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await productRepository.Get(id));
        }
    }
}