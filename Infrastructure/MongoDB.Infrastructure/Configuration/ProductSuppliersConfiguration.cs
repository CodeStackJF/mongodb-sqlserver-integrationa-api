using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Infrastructure.Configuration;

public class ProductSuppliersConfiguration : IEntityTypeConfiguration<products_suppliers>
    {
        public void Configure(EntityTypeBuilder<products_suppliers> builder)
        {
            builder.HasKey(x => new
            {
                x.product_id,
                x.supplier_id
            });

            builder.HasOne(x=>x.product).WithMany(x=>x.product_supplier).HasForeignKey(x=>x.product_id);
            builder.HasOne(x=>x.supplier).WithMany().HasForeignKey(x=>x.supplier_id);
        }
    }