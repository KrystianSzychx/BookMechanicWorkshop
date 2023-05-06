using BookMechanicWorkshop_.DbContexts;
using BookMechanicWorkshop_.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMechanicWorkshop_.Repositories
{
    public class ServiceMechanicWorkshopRepository : IServiceMechanicWorkshopRepository
    {
        private readonly MechanicWorkshopContext _context;

        public ServiceMechanicWorkshopRepository(MechanicWorkshopContext context)
        {
            _context = context;
        }
		public async Task<ServiceMechanicWorkshop> GetServiceById(int serviceId)
		{
			var service = await _context.ServicesMechanicWorkshop
				.Include(s => s.MechanicWorkshop)
				.FirstOrDefaultAsync(s => s.ServiceId == serviceId);

			return service;
		}
		public async Task<IEnumerable<ServiceMechanicWorkshop>> GetServicesByMechanicWorkshopId(int mechanicWorkshopId)
        {
            var services = await _context.ServicesMechanicWorkshop
                .Where(s => s.MechanicWorkshopId == mechanicWorkshopId)
                .ToListAsync();

            return services;    
        }

        public void AddServiceForMechanicWorkshop(ServiceMechanicWorkshop service)
        {
            _context.ServicesMechanicWorkshop.Add(service);
            _context.SaveChanges();
        }
    }
}
