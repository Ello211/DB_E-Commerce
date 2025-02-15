using Microsoft.AspNetCore.Mvc;
using MediatR;
using DB_ECommerce.Application.Products;
using DB_ECommerce.MVC.ViewModels.Products;
using DB_ECommerce.Application.Reviews;
using Microsoft.Extensions.Caching.Distributed;
using DB_ECommerce.Models;
using System.Text.Json;


namespace DB_ECommerce.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(2);

        public ProductsController(IMediator mediator, IDistributedCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }

        private async Task SetProductToCache(Product product)
        {
            var key = $"product-{product.ProductID}";
            var productDto = new ProductDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                // Weitere Eigenschaften hier
            };

            var productAsSerializedJson = JsonSerializer.Serialize(productDto);
            await _cache.SetStringAsync(key, productAsSerializedJson, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _cacheDuration
            });
        }

        private async Task<Product> GetProductFromCache(int productId)
        {
            var key = $"product-{productId}";
            var productAsSerializedJson = await _cache.GetStringAsync(key);
            if (productAsSerializedJson == null)
            {
                return null;
            }

            var productDto = JsonSerializer.Deserialize<ProductDto>(productAsSerializedJson);
            var product = new Product
            {
                ProductID = productDto.ProductID,
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                // Weitere Eigenschaften hier
            };

            return product;
        }

        private async Task InvalidateCache(int productId)
        {
            var key = $"product-{productId}";
            await _cache.RemoveAsync(key);
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            var viewModel = products.Select(p => new ProductListViewModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.Price
            }).ToList();

            // Fetch all ratings
            var ratingTasks = products.Select(p =>
                _mediator.Send(new GetAverageRatingQuery(p.ProductID.ToString()))
            ).ToList();

            // Concurrently executes all rating requests
            var ratings = await Task.WhenAll(ratingTasks);

            // Assign ratings to products
            for (int i = 0; i < products.Count; i++)
            {
                viewModel[i].AverageRating = ratings[i];
            }

            return View(viewModel);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await GetProductFromCache(id) ?? await _mediator.Send(new GetProductQuery { ProductID = id });
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                OrderIds = product.Products_Orders.Select(po => po.ProductOrderID).ToList()
            };

            return View(viewModel);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateProductCommand
                {
                    ProductName = model.ProductName,
                    Price = model.Price
                };

                await _mediator.Send(command);
                var product = command.ToProduct();
                await SetProductToCache(product);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await GetProductFromCache(id) ?? await _mediator.Send(new GetProductQuery { ProductID = id });
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductUpdateViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price
            };

            return View(viewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateProductCommand
                {
                    ProductID = model.ProductID,
                    ProductName = model.ProductName,
                    Price = model.Price
                };

                await _mediator.Send(command);
                var product = command.ToProduct();
                await SetProductToCache(product);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await GetProductFromCache(id) ?? await _mediator.Send(new GetProductQuery { ProductID = id });
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price
            };

            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteProductCommand { ProductID = id });
            await InvalidateCache(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
