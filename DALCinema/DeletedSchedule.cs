using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALCinema
{
    public class DeletedSchedule
    {
        #region Variables
        private CinemaDbContext _cinema;
        #endregion
        #region Constructor
        public DeletedSchedule(CinemaDbContext context)
        {
            _cinema = context;
        }
        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; private set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Rooms { get; set; }
        public string Movies { get; set; }
        public  string Sits { get; set; }
        #endregion
    }
}
