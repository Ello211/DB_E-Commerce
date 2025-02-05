using DB_E_Commerce.E_Commerce.Application.Product_Orders;

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
                ProductId = this.ProductId,
                OrderId = this.OrderId,
                Quantity = this.Quantity
            };
        }
    }
}
