using Microsoft.AspNetCore.Mvc;
using MediatR;
using DB_ECommerce.MVC.ViewModels.Categories;
using DB_E_Commerce.E_Commerce.Application.Categories;
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
            var categoryViewModels = categories.Select(CategoryListViewModel.FromCategory).ToList();
            return View(categoryViewModels);
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
                var command = viewModel.ToCreateCategoryCommand();
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _mediator.Send(new GetCategoryQuery { Id = id });
            if (category == null) return NotFound();

            var viewModel = CategoryUpdateViewModel.FromCategory(category);
            return View(viewModel);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryUpdateViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _mediator.Send(viewModel.ToUpdateCategoryCommand());
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _mediator.Send(new GetCategoryQuery { Id = id });
            if (category == null) return NotFound();

            var viewModel = CategoryDetailsViewModel.FromCategory(category);
            return View(viewModel);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _mediator.Send(new GetCategoryQuery { Id = id });
            if (category == null) return NotFound();

            var viewModel = CategoryDetailsViewModel.FromCategory(category);
            return View(viewModel);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}

