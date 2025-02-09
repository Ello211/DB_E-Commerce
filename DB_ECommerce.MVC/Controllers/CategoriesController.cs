using MediatR;
using Microsoft.AspNetCore.Mvc;
using DB_ECommerce.MVC.ViewModels.Categories;
using DB_ECommerce.Application.Categories;
namespace DB_ECommerce.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            var viewModel = categories.Select(c => new CategoryListViewModel
            {
                Id = c.CategoryID,
                CategoryName = c.CategoryName
            }).ToList();

            return View(viewModel);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _mediator.Send(new GetCategoryQuery { CategoryID = id });
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryDetailsViewModel
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName
            };

            return View(viewModel);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateCategoryCommand
                {
                    CategoryName = viewModel.CategoryName
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _mediator.Send(new GetCategoryQuery { CategoryID = id });
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryUpdateViewModel
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName
            };

            return View(viewModel);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryUpdateViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateCategoryCommand
                {
                    CategoryID = viewModel.Id,
                    CategoryName = viewModel.CategoryName
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _mediator.Send(new GetCategoryQuery { CategoryID = id });
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryDetailsViewModel
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName
            };

            return View(viewModel);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { CategoryID = id });
            return RedirectToAction(nameof(Index));
        }
    }
}

