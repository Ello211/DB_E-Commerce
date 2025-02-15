using MediatR;
using Microsoft.AspNetCore.Mvc;
using DB_ECommerce.MVC.ViewModels.Orders;
using DB_ECommerce.Application.Orders;

namespace DB_ECommerce.MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = "Orders";

            var orders = await _mediator.Send(new GetOrdersQuery());
            var viewModel = orders.Select(o => new OrderListViewModel
            {
                OrderID = o.OrderID,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Customer = o.Customer,
                Payment = o.Payment,
            }).ToList();

            return View(viewModel);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _mediator.Send(new GetOrderQuery { OrderID = id });
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderDetailsViewModel
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer = order.Customer,
                Payment = order.Payment,
            };

            return View(viewModel);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateOrderCommand
                {
                    OrderDate = viewModel.OrderDate,
                    TotalPrice = viewModel.TotalPrice,
                    CustomerID = viewModel.CustomerID,
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _mediator.Send(new GetOrderQuery { OrderID = id });
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderUpdateViewModel
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer = order.Customer,
            };

            return View(viewModel);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderUpdateViewModel viewModel)
        {
            if (id != viewModel.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateOrderCommand
                {
                    OrderID = viewModel.OrderID,
                    OrderDate = viewModel.OrderDate,
                    TotalPrice = viewModel.TotalPrice,
                    CustomerID= viewModel.CustomerID,
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _mediator.Send(new GetOrderQuery { OrderID = id });
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderDetailsViewModel
            {
                OrderID= order.OrderID,
                OrderDate= order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer= order.Customer,
                Payment = order.Payment,
            };

            return View(viewModel);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { OrderID = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
