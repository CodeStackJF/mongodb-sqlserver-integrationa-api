using MongoDB.Domain.Mongo.Entities;

namespace MongoDB.Domain.Interfaces;

public interface IProductsRepository
{
    Task<List<productsCollection>> GetAll();
    Task<productsCollection> Get(int id);
    Task<productsCollection> Save(productsCollection product);
    Task Update(int id, productsCollection product);
    Task<bool> Exists(int id);
}