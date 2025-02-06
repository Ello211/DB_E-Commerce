using DB_E_Commerce.Models;

namespace DB_E_Commerce.Application.Orders
{
	public class OrderReferences
	{
		public List<Customer> Customers { get; set; }
		public List<Shipment> Shipments { get; set; }
		public List<Payment> Payments { get; set; }
	}
}
