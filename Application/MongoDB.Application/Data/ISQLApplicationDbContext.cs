using Microsoft.EntityFrameworkCore;
using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Application.Data
{
    public interface ISQLApplicationDbContext
    {
        DbSet<categories> categories {get; set;}
        DbSet<products> products {get; set;}
        DbSet<suppliers> suppliers {get; set;}
        DbSet<products_categories> products_categories {get; set;}
        DbSet<products_suppliers> products_suppliers {get; set;}
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}