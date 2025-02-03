using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_E_Commerce.E_Commerce.Models; //achtung
    

namespace DB_E_Commerce.E_Commerce.Persistence
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(product => product.ProductID); //Primärschlüssel

            builder.Property(product => product.ProductName).IsRequired();

            builder.Property(product => product.Price).IsRequired();

            /*
             builder.HasOne.....
             */
        }
    }
}
