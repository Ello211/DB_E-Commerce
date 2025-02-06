using DB_E_Commerce.E_Commerce.Application.Product_Orders;
using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Products_Orders
{
    public class ProductOrderUpdateViewModel
    {
        public int ProductOrderID { get; set; }
        public int Quantity { get; set; }

        public UpdateProductOrderCommand ToCommand()
        {
            return new UpdateProductOrderCommand
            {
                OrderId = this.ProductOrderID,
                Quantity = this.Quantity
            };
        }

        public static ProductOrderUpdateViewModel FromProductOrder(Product_Order productOrder)
        {
            return new ProductOrderUpdateViewModel
            {
                ProductOrderID = productOrder.ProductOrderID,
                Quantity = productOrder.Quantity
            };
        }
    }
}
