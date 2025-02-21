using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Domain.SQL.Entities;

namespace MongoDB.Infrastructure.Configuration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<categories>
    {
        public void Configure(EntityTypeBuilder<categories> builder)
        {
            builder.HasKey(x => new
            {
                x.id_category
            });
        }
    }
}