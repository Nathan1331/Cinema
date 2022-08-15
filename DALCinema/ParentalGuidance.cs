using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALCinema
{
    public class ParentalGuidance
    {
        // The Id has a private set so it cannot be changed.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentalGuidenceId { get; private set; }
        // This property will say the range of age
        public string Range { get; set; }
        // This 
        public string Name { get; set; }

    }
}
