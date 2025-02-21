using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Infrastructure.Configuration;

public class ProductsConfiguration : IEntityTypeConfiguration<products>
    {
        public void Configure(EntityTypeBuilder<products> builder)
        {
            builder.HasKey(x => new
            {
                x.id_product,
            });
        }
    }