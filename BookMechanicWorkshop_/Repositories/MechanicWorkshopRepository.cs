using BookMechanicWorkshop_.DbContexts;
using BookMechanicWorkshop_.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMechanicWorkshop_.Repositories
{
    public class MechanicWorkshopRepository : IMechanicWorkshopRepository
    {
        private readonly MechanicWorkshopContext _context;

        public MechanicWorkshopRepository(MechanicWorkshopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MechanicWorkshop>> GetAllMechanicWorkshopsAsync()
        {
            var mechanicWorkshops = await _context.MechanicWorkshops.ToListAsync();

            return mechanicWorkshops;
        }

        public async Task<IEnumerable<MechanicWorkshop>> GetMechanicWorkshopsByCityAsync(string city)
        {
            var mechanicWorkshop = await _context.MechanicWorkshops
                .Where(x => x.City == city)
                .ToListAsync();

            return mechanicWorkshop;
        }

        public async Task<MechanicWorkshop> GetMechanicWorkshop(int mechanicWorkshopId)
        {
            var mechanicWorkshop = await _context.MechanicWorkshops.FirstOrDefaultAsync(m => m.MechanicWorkshopId == mechanicWorkshopId);

            return mechanicWorkshop;
        }

        public void AddMechanicWorkshop(MechanicWorkshop mechanicWorkshop)
        {
            _context.MechanicWorkshops.Add(mechanicWorkshop);
            _context.SaveChanges();
        }
    }
}
