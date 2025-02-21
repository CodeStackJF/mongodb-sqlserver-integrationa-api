using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Domain.Interfaces;

public interface IProductsSQLRepository
{
    Task<List<products>> GetAll();
    Task<products> Get(int id);
    Task<products> GetFullEntity(int id);
    Task<products> Save(products product);
    Task Update(int id, products product);
    Task<bool> Exists(int id);
}