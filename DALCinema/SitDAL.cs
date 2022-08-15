using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALCinema
{
    public class SitDAL
    {
        private CinemaDbContext _db;
        public SitDAL(CinemaDbContext context)
        {
            _db = context;
        }

        public ICollection<Sit> ListOfSits()
        {
            return null;
        }
        public bool AddSit(Sit sit)
        {
            if(sit.ScheduleId > 0) 
            {
                try
                {
                    _db.Sits.Add(sit);
                    return true;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
            return false;
        }
        public bool DeleteSit(Sit sit)
        {
            return false;
        }
        public bool EditSit(Sit sit)
        {
            return false;
        }
    }
}
