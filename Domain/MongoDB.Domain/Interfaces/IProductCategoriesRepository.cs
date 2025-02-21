using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Domain.Interfaces
{
    public interface IProductCategoriesRepository
    {
        Task<List<products_categories>> GetAll();
        Task<products_categories> Get(int product_id, int category_id);
    }
}