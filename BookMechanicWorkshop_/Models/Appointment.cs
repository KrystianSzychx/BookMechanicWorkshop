using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BookMechanicWorkshop_.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("ServiceMechanicWorkshop")]
        public int ServiceMechanicWorkshopId { get; set; }
        public int Duration { get; set; }
        public ServiceMechanicWorkshop ServiceMechanicWorkshop { get; set; }


        [ForeignKey("MechanicWorkshop")]
        public int MechanicWorkshopId { get; set; }
        public MechanicWorkshop MechanicWorkshop { get; set; }





    }
}


