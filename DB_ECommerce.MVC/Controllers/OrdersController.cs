using MediatR;
using Microsoft.AspNetCore.Mvc;
using DB_ECommerce.MVC.ViewModels.Orders;
using DB_E_Commerce.E_Commerce.Application.Orderss;

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
            var orders = await _mediator.Send(new GetOrdersQuery());
            var viewModel = orders.Select(o => new OrderListViewModel
            {
                Id = o.OrderID,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount
            }).ToList();

            return View(viewModel);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _mediator.Send(new GetOrderQuery { Id = id });
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderDetailsViewModel
            {
                //anpassen
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
                    //anpassen
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _mediator.Send(new GetOrderQuery { Id = id });
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderUpdateViewModel
            {
                //anpassen
            };

            return View(viewModel);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderUpdateViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateOrderCommand
                {
                    //anpassen
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _mediator.Send(new GetOrderQuery { Id = id });
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderDetailsViewModel
            {
                //anpassen
            };

            return View(viewModel);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
