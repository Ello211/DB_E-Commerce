using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_E_Commerce.Models;

namespace DB_E_Commerce.Persistence.Configuration
{
    public class CustomerInfoConfiguration : IEntityTypeConfiguration<CustomerInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerInfo> builder)
        {
            builder.HasKey(customerinfo => customerinfo.ProductID);

            builder.Property(customerinfo => customerinfo.Lastname).HasMaxLength(50).IsRequired();
            builder.Property(customerinfo => customerinfo.Firstname).IsRequired();
            builder.Property(customerinfo => customerinfo.Adress).HasMaxLength(200).IsRequired();
            builder.Property(customerinfo => customerinfo.Birthdate);
            builder.Property(customerinfo => customerinfo.AccountCreated).IsRequired();
            builder.Property(customerinfo => customerinfo.Email).HasMaxLength(200).IsRequired();


            builder.HasOne(customerinfo => customerinfo.CategoryID)
                .WithOne(customer => customer.CategoryID);
        }
    }
}
