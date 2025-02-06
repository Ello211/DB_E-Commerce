using Microsoft.AspNetCore.Mvc;
using MediatR;
using DB_ECommerce.MVC.ViewModels.Customers;
using DB_ECommerce.Application.Customers;

namespace DB_ECommerce.MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _mediator.Send(new GetCustomersQuery());
            var viewModel = customers.Select(c => new CustomerListViewModel
            {
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                Birthday = c.Birthday,
                AccountCreated = c.AccountCreated,
                Email = c.Email,
            
            }).ToList();

            return View(viewModel);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery { CustomerID = id });
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerDetailsViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Birthday = customer.Birthday,
                AccountCreated = customer.AccountCreated,
                Email = customer.Email,
            };

            return View(viewModel);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateCustomerCommand
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Address = viewModel.Address,
                    Birthday= viewModel.Birthday,
                    Email = viewModel.Email,
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery { CustomerID = id });
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerUpdateViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Birthday = customer.Birthday,
                AccountCreated = customer.AccountCreated,
                Email = customer.Email,
            };

            return View(viewModel);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerUpdateViewModel viewModel)
        {
            if (id != viewModel.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateCustomerCommand
                {
                    CustomerID = viewModel.CustomerID,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Address = viewModel.Address,
                    Birthday = viewModel.Birthday,
                    AccountCreated = viewModel.AccountCreated,
                    Email = viewModel.Email,
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery { CustomerID = id });
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerDetailsViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Birthday = customer.Birthday,
                AccountCreated = customer.AccountCreated,
                Email = customer.Email,
            };

            return View(viewModel);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteCustomerCommand { CustomerID = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
