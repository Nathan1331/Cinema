using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALCinema
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; private set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Length { get; set; }
        public string Category { get; set; }

        public string Language { get; set; }

        [Display(Name="ParentalGuidance")]
        public virtual int ParentalGuidenceId { get; set; }
        [ForeignKey("ParentalGuidenceId")]
        public virtual ParentalGuidance ParentalGuidances { get; set; }

    }
}
