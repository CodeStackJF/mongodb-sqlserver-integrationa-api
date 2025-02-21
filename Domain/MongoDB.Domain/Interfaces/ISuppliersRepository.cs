using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Domain.Interfaces
{
    public interface ISuppliersRepository
    {
         Task<List<suppliers>> GetAll();
    }
}