using using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_E_Commerce.Models;

namespace University.Persistence.Configuration;

public class MarkConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.CategoryID);

        builder.Property(category => category.CategoryName).HasMaxLength(50).IsRequired();
    }
}