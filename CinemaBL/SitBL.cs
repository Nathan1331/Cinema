using DALCinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCinema
{
    public class SitBL
    {
        SitDAL sitDAL;
        public ICollection<Sit> ListOfSits()
        {
            return null;
        }
        public bool AddSit(Sit sit)
        {
            if (sitDAL.AddSit(sit)) 
            { 
                return true; 
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
