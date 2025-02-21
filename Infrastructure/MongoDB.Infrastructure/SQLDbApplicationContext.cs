using Microsoft.EntityFrameworkCore;
using MongoDB.Application.Data;
using MongoDB.Domain.SQL.Entities;
using MongoDB.Domain.Primitives;

namespace MongoDB.Infrastructure
{
    public class SQLDbApplicationContext : DbContext, ISQLApplicationDbContext, IUnitOfWork
    {
        public SQLDbApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<categories> categories { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<suppliers> suppliers { get; set; }
        public DbSet<products_categories> products_categories  { get; set; }
        public DbSet<products_suppliers> products_suppliers  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SQLDbApplicationContext).Assembly);
        }
    }
}