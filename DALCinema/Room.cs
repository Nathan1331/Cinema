using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALCinema
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; private set; }
        public string Name { get; set; }
        public int AmountSits { get; set; }
        public double SitsPrice { get; set; }

    }
}
