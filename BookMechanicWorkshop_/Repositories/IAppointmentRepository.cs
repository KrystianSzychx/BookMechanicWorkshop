using BookMechanicWorkshop_.Models;

namespace BookMechanicWorkshop_.Repositories
{
    public interface IAppointmentRepository
    {
        public void BookAnAppointment(Appointment appointemnt);
        //public List<DateTime> GetBookedDatesForService(int mechanicWorkshopId, int serviceId);
        public List<DateTime> GetBookedDatesForMechanicWorkshop(int mechanicWorkshopId);





    }
}
