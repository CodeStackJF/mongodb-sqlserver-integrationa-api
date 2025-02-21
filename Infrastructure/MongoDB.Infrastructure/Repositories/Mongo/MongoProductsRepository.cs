using Microsoft.Extensions.Configuration;
using MongoDB.Domain.Mongo.Entities;
using MongoDB.Domain.Interfaces;
using MongoDB.Driver;

namespace MongoDB.Infrastructure.Repositories.Mongo
{
    public class MongoProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<productsCollection> productsCollection;
        public MongoProductsRepository(IConfiguration conf)
        {
            productsCollection = new MongoClient(conf.GetSection("MongoDB").GetValue<string>("ConnectionString")).GetDatabase("UGBStore").GetCollection<productsCollection>("products");
        }

        public async Task<productsCollection> Get(int id)
        {
            return await productsCollection.Find(x=>x.id_product == id).FirstOrDefaultAsync();
        }

        public async Task<List<productsCollection>> GetAll()
        {
            return await productsCollection.Find(x=>true).ToListAsync();
        }

        public async Task<productsCollection> Save(productsCollection product)
        {
            await productsCollection.InsertOneAsync(product);
            return product;
        }

        public async Task Update(int id_product, productsCollection product)
        {
            var result = await productsCollection.Find(x=>x.id_product == id_product).FirstOrDefaultAsync();
            await productsCollection.ReplaceOneAsync(result.Id, product);
        }

        public async Task<bool> Exists(int id)
        {
            return await productsCollection.Find(x=>x.id_product == id).AnyAsync();
        }

        public async Task<productsCollection> GetFullObject(int id)
        {
            return new productsCollection();
        }
    }
}