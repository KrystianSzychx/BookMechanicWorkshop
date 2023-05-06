using BookMechanicWorkshop_.DbContexts;
using BookMechanicWorkshop_.Models;
using BookMechanicWorkshop_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookMechanicWorkshop_.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IServiceMechanicWorkshopRepository _serviceMechanicWorkshopRepository;

       

        public AppointmentController(IAppointmentRepository appointmentRepository,
            IServiceMechanicWorkshopRepository serviceMechanicWorkshopRepository,
            IMechanicWorkshopRepository mechanicWorkshopRepository)
        {
            _appointmentRepository = appointmentRepository;
            _serviceMechanicWorkshopRepository = serviceMechanicWorkshopRepository;
          
        }
        /// <summary>
        /// Creates a new appointment based on the submitted appointment data.
        /// </summary>
        /// <param name="appointment">The appointment data to use for creating the appointment.</param>
        /// <returns>A redirect to the home page if the appointment was created successfully,
        /// or a redirect to the appointment form with an error message if an error occurred.</returns>
        [HttpPost]
		public async Task<IActionResult> CreateAppointment(Appointment appointment)
		{
            try
            {
                var service = await _serviceMechanicWorkshopRepository.GetServiceById(appointment.ServiceMechanicWorkshopId);
                appointment.Duration = service.Duration;
                appointment.EndTime = appointment.StartTime.AddMinutes(appointment.Duration);

                //  appointment.Duration = service.Duration;
                _appointmentRepository.BookAnAppointment(appointment);
                TempData["SuccessMessage"] = "Termin został zarezerwowany.";    
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("AppointmentForm", "Appointment");
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Action method that returns a view for creating a new appointment,
        /// populated with services available at the specified mechanic workshop.
        /// </summary>
        /// <param name="mechanicWorkshopId">The ID of the mechanic workshop to get services for.</param>
        /// <returns>A view for creating a new appointment.</returns>
        
        [Authorize]
        public async Task<IActionResult> AppointmentForm(int mechanicWorkshopId)
        {
            var services = await _serviceMechanicWorkshopRepository.GetServicesByMechanicWorkshopId(mechanicWorkshopId);
            ViewData["MechanicWorkshopId"] = mechanicWorkshopId;
            ViewData["Services"] = services;

            var appointment = new Appointment
            {
                MechanicWorkshopId = mechanicWorkshopId
            };
            return View(appointment);
        }


        /// <summary>
        /// Action method that retrieves all available dates for a selected mechanic workshop from the database and returns them to the view in ISO 8601 format.
        /// </summary>
        /// <param name="mechanicWorkshopId">The ID of the selected mechanic workshop</param>
        /// <returns>The ChooseDate view with the available dates and mechanic workshop ID passed as ViewData</returns>
        public IActionResult ChooseDate(int mechanicWorkshopId)
        {
            // Pobierz z bazy danych wszystkie dostępne daty dla wybranego warsztatu

            var availableDates = _appointmentRepository.GetBookedDatesForMechanicWorkshop(mechanicWorkshopId);

            // Utwórz listę dat w formacie ISO 8601

            var datesList = availableDates.Select(date => date.ToString("yyyy-MM-dd HH:mm"));

            //  Przekaż listę dat do widoku
            ViewData["AvailableDates"] = JsonConvert.SerializeObject(datesList);



            //  Przekaż także identyfikatory warsztatu
            ViewData["MechanicWorkshopId"] = mechanicWorkshopId;            

            return View();
        }
    }
}



