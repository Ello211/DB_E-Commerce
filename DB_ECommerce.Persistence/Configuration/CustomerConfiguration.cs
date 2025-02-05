using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.CustomerID);

        builder.Property(customerinfo => customerinfo.Lastname).HasMaxLength(50).IsRequired();
        builder.Property(customerinfo => customerinfo.Firstname).IsRequired();
        builder.Property(customerinfo => customerinfo.Address).HasMaxLength(50).IsRequired();
        builder.Property(customerinfo => customerinfo.Birthday);
        builder.Property(customerinfo => customerinfo.AccountCreated).IsRequired();
        builder.Property(customerinfo => customerinfo.Email).HasMaxLength(50).IsRequired();
    }
}