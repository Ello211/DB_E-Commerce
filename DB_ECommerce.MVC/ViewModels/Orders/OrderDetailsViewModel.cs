﻿using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public int OrderID {  get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public string PaymentDisplay => Payment != null ? Payment.PaymentID.ToString() : "No payment";

        public static OrderDetailsViewModel FromOrder(DB_ECommerce.Models.Order order)
        {
            return new OrderDetailsViewModel
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer = order.Customer,
                Payment = order.Payment,
            };
        }
    }
}
