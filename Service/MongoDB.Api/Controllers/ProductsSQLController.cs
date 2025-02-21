using Microsoft.AspNetCore.Mvc;
using MongoDB.Domain.SQL.Entities;
using MongoDB.Domain.Mongo.Entities;
using MongoDB.Domain.Interfaces;
using MongoDB.Infrastructure.Repositories.Mongo;
using MongoDB.Infrastructure.Repositories.SQLServer;
using AutoMapper;

namespace MongoDB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsSQLController : ControllerBase
    {
        private readonly IProductsSQLRepository sQLProductsRepository;
        private readonly IProductsRepository mongoProductsRepository;
        private readonly IMapper mapper;
        public ProductsSQLController(IProductsSQLRepository _sQLProductsRepository, IProductsRepository _mongoProductsRepository, IMapper _mapper)
        {
            sQLProductsRepository = _sQLProductsRepository;
            mongoProductsRepository = _mongoProductsRepository;
            mapper = _mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] products product)
        {
            await sQLProductsRepository.Save(product);
            var productObject = await sQLProductsRepository.GetFullEntity(product.id_product);
            var productsCollection = mapper.Map<productsCollection>(productObject);
            var result = await mongoProductsRepository.Save(productsCollection);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await sQLProductsRepository.GetAll());
        }
    }
}