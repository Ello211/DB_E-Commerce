using DB_ECommerce.MVC.ViewModels.Shipments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DB_ECommerce.Application.Shipments;

namespace DB_ECommerce.MVC.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly IMediator _mediator;

        public ShipmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Shipments
        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = "Shipments";

            var shipments = await _mediator.Send(new GetShipmentsListQuery());
            var viewModel = shipments.Select(s => new ShipmentListViewModel
            {
                ShipmentID = s.ShipmentID,
                TrackingNumber = s.TrackingNumber,
                ShipmentStatus = s.ShipmentStatus,
                ShipmentDate = s.ShipmentDate,
                DeliveryDate = s.DeliveryDate
            }).ToList();

            return View(viewModel);
        }

        // GET: Shipments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var shipment = await _mediator.Send(new GetShipmentQuery { ShipmentID = id });

            if (shipment == null)
                return NotFound();

            var viewModel = new ShipmentDetailsViewModel
            {
                ShipmentID = shipment.ShipmentID,
                TrackingNumber = shipment.TrackingNumber,
                ShipmentStatus = shipment.ShipmentStatus,
                ShipmentDate = shipment.ShipmentDate,
                DeliveryDate = shipment.DeliveryDate,
                OrderId = shipment.Order.OrderID
            };

            return View(viewModel);
        }

        // GET: Shipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shipments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShipmentCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new CreateShipmentCommand
            {
                ShipmentDate = model.ShipmentDate,
                TrackingNumber = model.TrackingNumber,
                DeliveryDate = model.DeliveryDate,
                ShipmentStatus = model.ShipmentStatus,
                OrderID = model.OrderId
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: Shipments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var shipment = await _mediator.Send(new GetShipmentQuery { ShipmentID = id });

            if (shipment == null)
                return NotFound();

            var viewModel = new ShipmentUpdateViewModel
            {
                ShipmentID = shipment.ShipmentID,
                ShipmentDate = shipment.ShipmentDate,
                TrackingNumber = shipment.TrackingNumber,
                DeliveryDate = shipment.DeliveryDate,
                ShipmentStatus = shipment.ShipmentStatus,
                OrderId = shipment.Order.OrderID
            };

            return View(viewModel);
        }

        // POST: Shipments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShipmentUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new UpdateShipmentCommand
            {
                ShipmentID = model.ShipmentID,
                ShipmentDate = model.ShipmentDate,
                TrackingNumber = model.TrackingNumber,
                DeliveryDate = model.DeliveryDate,
                ShipmentStatus = model.ShipmentStatus,
                OrderID = model.OrderId
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: Shipments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var shipment = await _mediator.Send(new GetShipmentQuery { ShipmentID = id });

            if (shipment == null)
                return NotFound();

            var viewModel = new ShipmentDetailsViewModel
            {
                ShipmentID = shipment.ShipmentID,
                TrackingNumber = shipment.TrackingNumber,
                ShipmentStatus = shipment.ShipmentStatus,
                ShipmentDate = shipment.ShipmentDate,
                DeliveryDate = shipment.DeliveryDate
            };

            return View(viewModel);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteShipmentCommand { ShipmentID = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
