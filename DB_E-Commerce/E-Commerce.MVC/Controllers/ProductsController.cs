using MediatR;

using Microsoft.AspNetCore.Mvc;

using DB_E_Commerce.E_Commerce.Application.Products;
using DB_E_Commerce.E_Commerce.MVC.ViewModels.Products;

namespace DB_E_Commerce.E_Commerce.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var getProductsQuery = new GetProductsQuery();
            var products = await this.mediator.Send(getProductsQuery);

            var productListViewModels = products.Select(ProductListViewModel.FromProduct).ToList();

            return View(productListViewModels);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getProductQuery = new GetProductQuery { Id = id.Value };
            var product = await this.mediator.Send(getProductQuery);

            if (product == null)
            {
                return NotFound();
            }

            var productDetailsViewModel = ProductDetailsViewModel.FromProduct(product);

            return View(productDetailsViewModel);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel productCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createProductCommand = productCreateViewModel.ToCreateProductCommand();
                await mediator.Send(createProductCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(productCreateViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getProductQuery = new GetProductQuery { Id = id.Value };
            var product = await this.mediator.Send(getProductQuery);

            var productUpdateViewModel = ProductUpdateViewModel.FromProduct(product);
            return View(productUpdateViewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUpdateViewModel productUpdateViewModel)
        {
            if (id != productUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateProductCommand = productUpdateViewModel.ToUpdateProducttCommand();
                await this.mediator.Send(updateProductCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(productUpdateViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getProductQuery = new GetProductQuery { Id = id.Value };
            var product = await this.mediator.Send(getProductQuery);
            if (product == null)
            {
                return NotFound();
            }

            var productDetailsViewModel = ProductDetailsViewModel.FromProduct(product);

            return View(productDetailsViewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteProductCommand = new DeleteProductCommand { Id = id };
            await this.mediator.Send(deleteProductCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}
