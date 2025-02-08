using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Orders
{
	public class OrderReferences
	{
		public List<Customer> Customers { get; set; }
		public List<Shipment> Shipments { get; set; }
		public List<Payment> Payments { get; set; }
	}
}
