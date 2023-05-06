using BookMechanicWorkshop_.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMechanicWorkshop_.DbContexts
{
    public class MechanicWorkshopContext : DbContext
    {
        public DbSet<MechanicWorkshop> MechanicWorkshops { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ServiceMechanicWorkshop> ServicesMechanicWorkshop { get; set; }

        public MechanicWorkshopContext(DbContextOptions<MechanicWorkshopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.MechanicWorkshop)
            .WithMany(m => m.Appointments)
            .HasForeignKey(a => a.MechanicWorkshopId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
