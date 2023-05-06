using BookMechanicWorkshop_.Models;

namespace BookMechanicWorkshop_.Repositories
{
    public interface IServiceMechanicWorkshopRepository
    {
        public Task<IEnumerable<ServiceMechanicWorkshop>> GetServicesByMechanicWorkshopId(int mechanicWorkshopId);
		public Task<ServiceMechanicWorkshop> GetServiceById(int serviceId);
        void AddServiceForMechanicWorkshop(ServiceMechanicWorkshop service);
	}
}
