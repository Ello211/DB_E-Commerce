using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.CategoryID);

        builder.Property(category => category.CategoryName).HasMaxLength(50).IsRequired();
    }
}