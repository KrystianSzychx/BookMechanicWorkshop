using BookMechanicWorkshop_.Models;

namespace BookMechanicWorkshop_.Repositories
{
    public interface IMechanicWorkshopRepository
    {
        Task<IEnumerable<MechanicWorkshop>> GetAllMechanicWorkshopsAsync();
        Task<IEnumerable<MechanicWorkshop>> GetMechanicWorkshopsByCityAsync(string city);
        Task<MechanicWorkshop> GetMechanicWorkshop(int mechanicWorkshopId);
        void AddMechanicWorkshop(MechanicWorkshop mechanicWorkshop);
    }
}
