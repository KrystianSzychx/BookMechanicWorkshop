using BookMechanicWorkshop_.Models;
using BookMechanicWorkshop_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookMechanicWorkshop_.Controllers
{
    public class MechanicWorkshopController : Controller
    {
        
        private readonly IMechanicWorkshopRepository _mechanicWorkshopRepository;

        public MechanicWorkshopController(IMechanicWorkshopRepository mechanicWorkshopRepository)
        {
            _mechanicWorkshopRepository = mechanicWorkshopRepository;
        }

        /// <summary>
        /// HTTP GET action that returns a view with a list of all mechanic workshops.
        /// </summary>
        /// <returns>A view with a list of all mechanic workshops.</returns>
        [HttpGet]
        public async Task<IActionResult> MechanicWorkshops()
        {
            var mechanicWorkshops = await _mechanicWorkshopRepository.GetAllMechanicWorkshopsAsync();

            return View(mechanicWorkshops);
        }

        /// <summary>
        /// Retrieves all mechanic workshops in a specified city.
        /// </summary>
        /// <param name="city">The name of the city.</param>
        /// <returns>The view that displays all mechanic workshops in the specified city.</returns>
        [HttpGet]
        public async Task<IActionResult> MechanicWorkshopsByCity(string city)
        {
            var mechanicWorkshop = await _mechanicWorkshopRepository.GetMechanicWorkshopsByCityAsync(city);
            return View("MechanicWorkshopsByCity", mechanicWorkshop);
        }

        /// <summary>
        /// Action method that displays the form for adding a new mechanic workshop.
        /// </summary>
        /// <returns>A view displaying the form for adding a new mechanic workshop.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddMechanicWorkshopForm()
        {
            return View();
        }

        /// <summary>
        /// Displays the form for adding a new mechanic workshop
        /// </summary>
        /// <returns>The view for adding a new mechanic workshop</returns>        
        [HttpPost]
        public async Task<ActionResult> AddMechanicWorkshop(MechanicWorkshop mechanicWorkshop)
        {
            try
            {
                _mechanicWorkshopRepository.AddMechanicWorkshop(mechanicWorkshop);
                TempData["SuccessMessage"] = "Warsztat został dodany";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("AddMechanicWorkshopForm", "MechanicWorkshop");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
