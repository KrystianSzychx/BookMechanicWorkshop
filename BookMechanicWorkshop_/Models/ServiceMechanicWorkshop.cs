using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMechanicWorkshop_.Models
{
    public class ServiceMechanicWorkshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string PriceRange { get; set; }
        

        [ForeignKey("MechanicWorkshop")]
        public int MechanicWorkshopId { get; set; } 
        public MechanicWorkshop MechanicWorkshop { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
