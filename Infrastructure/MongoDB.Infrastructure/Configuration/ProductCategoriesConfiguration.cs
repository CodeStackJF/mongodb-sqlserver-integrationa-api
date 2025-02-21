using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Infrastructure.Configuration;

public class ProductCategoriesConfiguration : IEntityTypeConfiguration<products_categories>
    {
        public void Configure(EntityTypeBuilder<products_categories> builder)
        {
            builder.HasKey(x => new
            {
                x.product_id,
                x.category_id
            });

            builder.HasOne(x=>x.product).WithMany(x=>x.product_category).HasForeignKey(x=>x.product_id);
            builder.HasOne(x=>x.category).WithMany().HasForeignKey(x=>x.category_id);
        }
    }