using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DB_ECommerce.Application.Payments;
using DB_ECommerce.MVC.ViewModels.Payments;

namespace DB_ECommerce.MVC.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var payments = await _mediator.Send(new GetPaymentsListQuery());
            var viewModel = new List<PaymentListViewModel>();

            foreach (var payment in payments)
            {
                viewModel.Add(new PaymentListViewModel
                {
                    PaymentID = payment.PaymentID,
                    Currency = payment.Currency,
                    PaymentMethod = payment.PaymentMethod,
                    PaymentStatus = payment.PaymentStatus,
                    PaymentAmount = payment.PaymentAmount,
                    OpenPayment = payment.OpenPayment
                });
            }

            return View(viewModel);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var payment = await _mediator.Send(new GetPaymentQuery { PaymentID = id });

            if (payment == null)
            {
                return NotFound();
            }

            var viewModel = new PaymentDetailsViewModel
            {
                PaymentID = payment.PaymentID,
                Currency = payment.Currency,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                PaymentAmount = payment.PaymentAmount,
                OpenPayment = payment.OpenPayment
            };

            return View(viewModel);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreatePaymentCommand
                {
                    Currency = model.Currency,
                    PaymentMethod = model.PaymentMethod,
                    PaymentStatus = model.PaymentStatus,
                    PaymentAmount = model.PaymentAmount,
                    OpenPayment = model.OpenPayment
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _mediator.Send(new GetPaymentQuery { PaymentID = id });

            if (payment == null)
            {
                return NotFound();
            }

            var viewModel = new PaymentUpdateViewModel
            {
                PaymentID = payment.PaymentID,
                Currency = payment.Currency,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                PaymentAmount = payment.PaymentAmount,
                OpenPayment = payment.OpenPayment
            };

            return View(viewModel);
        }

        // POST: Payments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentUpdateViewModel model)
        {
            if (id != model.PaymentID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdatePaymentCommand
                {
                    PaymentID = model.PaymentID,
                    Currency = model.Currency,
                    PaymentMethod = model.PaymentMethod,
                    PaymentStatus = model.PaymentStatus,
                    PaymentAmount = model.PaymentAmount,
                    OpenPayment = model.OpenPayment
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _mediator.Send(new GetPaymentQuery { PaymentID = id });

            if (payment == null)
            {
                return NotFound();
            }

            var viewModel = new PaymentDetailsViewModel
            {
                PaymentID = payment.PaymentID,
                Currency = payment.Currency,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                PaymentAmount = payment.PaymentAmount,
                OpenPayment = payment.OpenPayment
            };

            return View(viewModel);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeletePaymentCommand { PaymentID = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
