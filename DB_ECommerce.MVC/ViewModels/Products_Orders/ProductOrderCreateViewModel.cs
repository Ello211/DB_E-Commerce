using DB_ECommerce.Application.Product_Orders;

namespace DB_ECommerce.MVC.ViewModels.Products_Orders
{
    public class ProductOrderCreateViewModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public CreateProductOrderCommand ToCommand()
        {
            return new CreateProductOrderCommand
            {
                ProductID = this.ProductId,
                OrderID = this.OrderId,
                Quantity = this.Quantity
            };
        }
    }
}
