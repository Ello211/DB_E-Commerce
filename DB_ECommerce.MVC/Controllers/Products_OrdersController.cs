using MediatR;
using Microsoft.AspNetCore.Mvc;
using DB_ECommerce.MVC.ViewModels.Products_Orders;
using DB_E_Commerce.E_Commerce.Application.Product_Orders;

namespace DB_ECommerce.MVC.Controllers
{
    public class Products_OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public Products_OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Products_Orders
        public async Task<IActionResult> Index()
        {
            var productOrders = await _mediator.Send(new GetProductsOrdersQuery());
            var viewModel = productOrders.Select(ProductOrderListViewModel.FromProductOrder).ToList();
            return View(viewModel);
        }

        // GET: Products_Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var productOrder = await _mediator.Send(new GetProductOrderQuery { ProductId = id });
            if (productOrder == null)
            {
                return NotFound();
            }
            var viewModel = ProductOrderDetailsViewModel.FromProductOrder(productOrder);
            return View(viewModel);
        }

        // GET: Products_Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products_Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductOrderCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(viewModel.ToCommand());
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Products_Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var productOrder = await _mediator.Send(new GetProductOrderQuery { ProductId = id });
            if (productOrder == null)
            {
                return NotFound();
            }
            var viewModel = ProductOrderUpdateViewModel.FromProductOrder(productOrder);
            return View(viewModel);
        }

        // POST: Products_Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductOrderUpdateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(viewModel.ToCommand());
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Products_Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var productOrder = await _mediator.Send(new GetProductOrderQuery { ProductId = id });
            if (productOrder == null)
            {
                return NotFound();
            }
            var viewModel = ProductOrderDetailsViewModel.FromProductOrder(productOrder);
            return View(viewModel);
        }

        // POST: Products_Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteProductOrderCommand { ProductId = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
