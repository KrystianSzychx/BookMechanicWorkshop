using BookMechanicWorkshop_.DbContexts;
using BookMechanicWorkshop_.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMechanicWorkshop_.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MechanicWorkshopContext _context;

        public AppointmentRepository(MechanicWorkshopContext context)
        {
            _context = context;
        }

        public void BookAnAppointment(Appointment appointment)
        {
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.Duration);

			var conflictingAppointment = _context.Appointments.FirstOrDefault(a =>
		    (appointment.StartTime >= a.StartTime && appointment.StartTime < a.EndTime) || // New appointment starts during existing appointment
		    (appointment.EndTime > a.StartTime && appointment.EndTime <= a.EndTime) || // New appointment ends during existing appointment
		    (appointment.StartTime <= a.StartTime && appointment.EndTime >= a.EndTime) // New appointment completely overlaps existing appointment
	    );

			if (conflictingAppointment != null)
			{
				throw new InvalidOperationException("Ten termin jest już zajęty. Wybierz inny termin.");
			}

			_context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public List<DateTime> GetBookedDatesForMechanicWorkshop(int mechanicWorkshopId)
        {

            // Pobierz z bazy danych wszystkie dostępne daty dla wybranego warsztatu
            var bookedDates = _context.Appointments
                .Where(a => a.MechanicWorkshopId == mechanicWorkshopId)
                .Select(a => a.StartTime)
                .ToList();

            return bookedDates;
        }
    }
}
