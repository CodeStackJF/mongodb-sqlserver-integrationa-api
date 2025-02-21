using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Domain.Interfaces
{
    public interface IProductsSuppliersRepository
    {
        Task<List<products_suppliers>> GetAll();
        Task<products_suppliers> Get(int product_id, int supplier_id);
    }
}