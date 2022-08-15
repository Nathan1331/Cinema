using DALCinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCinema
{
    public class ScheduleBL
    {
        private Schedule scheduleDAL;
        public ScheduleBL(CinemaDbContext Context)
        {
            scheduleDAL = new Schedule(Context);
        }

        public bool DeletingOldSchedules() 
        {
            return scheduleDAL.DeleteOldSchedules();
            
        }
        public ICollection<Schedule> SearchSchedulesByDates(DateTime[] dates) 
        {
            if (scheduleDAL.SearchSchedulesByDatesDAL(dates) != null) {
                return scheduleDAL.SearchSchedulesByDatesDAL(dates); 
            }

            return null;
        }
        public ICollection<Schedule> SearchSchedulesByRoom(Room room)
        {
            if (scheduleDAL.SearchSchedulesByRoomDAL(room) != null)
            {
                return scheduleDAL.SearchSchedulesByRoomDAL(room);
            }
            return null;
        }
        public ICollection<Schedule> SearchSchedulesByMovie(Movie movie)
        {
            if (scheduleDAL.SearchSchedulesByMovieDAL(movie) != null)
            {
                return scheduleDAL.SearchSchedulesByMovieDAL(movie);
            }
            return null;
        }

        public ICollection<Schedule> ListOfSchedules()
        {
            return scheduleDAL.ScheduleList();
        }
        public bool AddSchedule(Schedule schedule, Double price)
        {
            if (schedule != null && schedule.Movies != null && schedule.Rooms != null && schedule.StartDateTime>DateTime.Now) 
            {
                try
                {
                    if (scheduleDAL.CheckScheduleDateIsNotBussy(schedule)==null) 
                    {
                        scheduleDAL.AddSchedule(schedule, price);
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }
                
            }
            
            return false;
        }
        public bool DeleteSchedule(Schedule schedule)
        {
            scheduleDAL.DeleteSchedule(schedule);
            return false;
        }
        public bool EditSchedule(Schedule schedule)
        {
            if (schedule == scheduleDAL.SearchScheduleById(schedule.ScheduleId))
            {
                return true;
            }
            else if (schedule.Rooms != scheduleDAL.SearchScheduleById(schedule.ScheduleId).Rooms)
            {
                scheduleDAL.EditScheduleRoom(schedule);
            }
            else
            {
                scheduleDAL.EditScheduleNameOrMovie(schedule);
            }
            return false;
        }
    }
}
