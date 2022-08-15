using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALCinema
{
    public class Sit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SitId { get; private set; }
        public string Name { get;  set; }
        public double Price { get; set; }
        public bool Availability { get; set; }

        public int ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
        public Schedule schedule { get; set; }
    }
}
