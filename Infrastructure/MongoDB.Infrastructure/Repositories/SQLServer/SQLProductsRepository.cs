using Microsoft.EntityFrameworkCore;
using MongoDB.Domain.SQL.Entities;
using MongoDB.Domain.Interfaces;

namespace MongoDB.Infrastructure.Repositories.SQLServer;

public class SQLProductsRepository : IProductsSQLRepository
{
    private readonly SQLDbApplicationContext ctx;

    public SQLProductsRepository(SQLDbApplicationContext _ctx)
    {
        ctx = _ctx;
    }

    public Task<bool> Exists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<products> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<products>> GetAll()
    {
        return ctx.products.ToListAsync();
    }

    public async Task<products> Save(products product)
    {
        ctx.products.Add(product);
        await ctx.SaveChangesAsync();
        return product;
    }

    public Task Update(int id, products product)
    {
        throw new NotImplementedException();
    }

    public async Task<products> GetFullEntity(int id)
    {
        var result = await ctx.products.Include("product_supplier.supplier").Include("product_category.category").Where(x=>x.id_product == id).FirstOrDefaultAsync();
        return result!;
    }
}