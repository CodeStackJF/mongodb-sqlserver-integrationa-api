using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Infrastructure.Configuration
{
    public class SuppliersConfiguration : IEntityTypeConfiguration<suppliers>
    {
        public void Configure(EntityTypeBuilder<suppliers> builder)
        {
            builder.HasKey(x => new
            {
                x.id_supplier
            });
        }
    }
}