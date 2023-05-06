using BookMechanicWorkshop_.Models;
using BookMechanicWorkshop_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookMechanicWorkshop_.Controllers
{
    public class ServiceMechanicWorkshopController : Controller
    {
        private readonly IServiceMechanicWorkshopRepository _serviceMechanicWorkshop;
        private readonly IMechanicWorkshopRepository _mechanicWorkshopRepository;

        public ServiceMechanicWorkshopController(IServiceMechanicWorkshopRepository serviceMechanicWorkshop, IMechanicWorkshopRepository mechanicWorkshopRepository)
        {
            _serviceMechanicWorkshop = serviceMechanicWorkshop;
            _mechanicWorkshopRepository = mechanicWorkshopRepository;
        }

        /// <summary>
        /// HTTP GET action that returns a view with a list of services available at a given mechanic workshop.
        /// </summary>
        /// <param name="mechanicWorkshopId">The ID of the mechanic workshop to get services for.</param>
        [HttpGet]
        public async Task<IActionResult> ServicesForMechanicWorkshop(int mechanicWorkshopId)
        {
            var services = await _serviceMechanicWorkshop.GetServicesByMechanicWorkshopId(mechanicWorkshopId);
			return View(services);
        }

        /// <summary>
        /// HTTP GET action that returns a view for adding a service to a mechanic workshop.
        /// </summary>
        /// <returns>The view for adding a service to a mechanic workshop.</returns>
        [Authorize]
        public async Task<IActionResult> AddServiceForMechanicWorkshopForm()
        {
            var mechanicWorkshops = await _mechanicWorkshopRepository.GetAllMechanicWorkshopsAsync();
            ViewBag.MechanicWorkshops = new SelectList(mechanicWorkshops, "MechanicWorkshopId", "Name");
            return View();
        }

        /// <summary>
        /// Adds a service for mechanic workshop with the following information: name, duration, price range, mechanicworkshop
        /// </summary>
        /// <param name="service"></param>
        /// <returns>An ActionResult representing the status of the operation.</returns>
        [HttpPost]
        public async Task<ActionResult> AddServiceForMechanicWorkshop(ServiceMechanicWorkshop service)
        {
            try
            {
                _serviceMechanicWorkshop.AddServiceForMechanicWorkshop(service);
                TempData["SuccessMessage"] = "Usługa dla danego warsztatu została dodana";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("AddServiceForMechanicWorkshopForm", "ServiceMechanicWorkshop   ");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
