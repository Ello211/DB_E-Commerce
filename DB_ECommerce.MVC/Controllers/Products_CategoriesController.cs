using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using DB_ECommerce.MVC.ViewModels.ProductCategories;
using DB_E_Commerce.E_Commerce.Application.Products_Categories;

namespace DB_ECommerce.MVC.Controllers
{
    public class Products_CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public Products_CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Products_Categories
        public async Task<IActionResult> Index()
        {
            var query = new GetProductsCategoriesQuery();
            var productCategories = await _mediator.Send(query);

            var viewModel = productCategories.Select(pc => new ProductCategoryListViewModel
            {
                ProductID = pc.ProductID,
                ProductName = pc.Product.ProductName,
                CategoryID = pc.CategoryID,
                CategoryName = pc.Category.CategoryName
            }).ToList();

            return View(viewModel);
        }

        // GET: Products_Categories/Details/5
        public async Task<IActionResult> Details(int productId, int categoryId)
        {
            var query = new GetProductCategoryQuery { ProductId = productId, CategoryId = categoryId };
            var productCategory = await _mediator.Send(query);

            if (productCategory == null)
            {
                return NotFound();
            }

            var viewModel = new ProductCategoryDetailsViewModel
            {
                ProductID = productCategory.ProductID,
                ProductName = productCategory.Product.ProductName,
                CategoryID = productCategory.CategoryID,
                CategoryName = productCategory.Category.CategoryName
            };

            return View(viewModel);
        }

        // GET: Products_Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products_Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateProductCategoryCommand
                {
                    ProductId = model.ProductID,
                    CategoryId = model.CategoryID
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Products_Categories/Edit/5
        public async Task<IActionResult> Edit(int productId, int categoryId)
        {
            var query = new GetProductCategoryQuery { ProductId = productId, CategoryId = categoryId };
            var productCategory = await _mediator.Send(query);

            if (productCategory == null)
            {
                return NotFound();
            }

            var viewModel = new ProductCategoryUpdateViewModel
            {
                ProductID = productCategory.ProductID,
                CategoryID = productCategory.CategoryID
            };

            return View(viewModel);
        }

        // POST: Products_Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int productId, int categoryId, ProductCategoryUpdateViewModel model)
        {
            if (productId != model.ProductID || categoryId != model.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateProductCategoryCommand
                {
                    ProductId = model.ProductID,
                    CategoryId = model.CategoryID
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Products_Categories/Delete/5
        public async Task<IActionResult> Delete(int productId, int categoryId)
        {
            var query = new GetProductCategoryQuery { ProductId = productId, CategoryId = categoryId };
            var productCategory = await _mediator.Send(query);

            if (productCategory == null)
            {
                return NotFound();
            }

            var viewModel = new ProductCategoryDetailsViewModel
            {
                ProductID = productCategory.ProductID,
                ProductName = productCategory.Product.ProductName,
                CategoryID = productCategory.CategoryID,
                CategoryName = productCategory.Category.CategoryName
            };

            return View(viewModel);
        }

        // POST: Products_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int productId, int categoryId)
        {
            var command = new DeleteProductCategoryCommand { ProductId = productId, CategoryId = categoryId };
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    }
}
