using NuGet.DependencyResolver;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Payments;

public class OrderReferences
{
    public List<Order> Orders { get; set; }
}