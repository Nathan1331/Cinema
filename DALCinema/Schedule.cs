using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DALCinema
{
    public class Schedule
    {
        #region Variables
        private CinemaDbContext _cinema;
        #endregion
        #region Constructor
        public Schedule(CinemaDbContext context)
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

        [Display(Name = "Room")]
        public virtual int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Rooms { get; set; }
        
        [Display(Name = "Movie")]
        public virtual int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movies { get; set; }

        public virtual ICollection<Sit> Sits { get; set; }
        #endregion

        #region Methods CRUD
        public bool AddSchedule(Schedule schedule, double price) 
        {
            try
            {
                //Adding the schedule to be able to use the ID
                _cinema.Schedules.Add(schedule);
                _cinema.SaveChanges();
                //Adding the sits that will be linked to the schedule that we just created
                string query = string.Format("USE [Cinema] {0}GO{0}DECLARE @count INT;{0}SET @count = 1;{0}WHILE @count<= {1}{0}Begin{0}INSERT INTO[dbo].[Sits]([Name],[Price],[ScheduleId])   VALUES('{2}', {3}, {4}){0}SET @count = @count + 1;{0}End{0}GO",Environment.NewLine,schedule.Rooms.AmountSits,"Regular Sit",price, schedule.ScheduleId);                
                _cinema.Sits.FromSqlRaw(query);
                _cinema.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }          
        }
        public bool DeleteSchedule(Schedule schedule)
        {
            try
            {
                //Deleting the sits that are related to the schedule that we want to delete
                string query = string.Format("USE [Cinema] {0}GO{0}DELETE FROM [dbo].Sits WHERE ScheduleId = {1};{0}GO", Environment.NewLine,schedule.ScheduleId);
                _cinema.Sits.FromSqlRaw(query);
                _cinema.SaveChanges();
                //Removing the Schedule once the sits have been deleted
                _cinema.Schedules.Remove(schedule);
                _cinema.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public bool DeleteOldSchedules() 
        {
            try
            {
                //Deleting the sits that are related to the schedule that we want to delete
                string queryFindingOldSchedules = string.Format("USE [Cinema] {0}GO{0}SELECT * FROM [dbo].[Schedules] WHERE DateStart < '{1}'{0}GO", Environment.NewLine, DateTime.Now);
                List<Schedule> oldSchedules = _cinema.Schedules.FromSqlRaw(queryFindingOldSchedules).ToList();

                    if (oldSchedules != null) {
                        foreach (Schedule schedule in oldSchedules) 
                        {
                        DeleteSchedule(schedule);
                        }
                    }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool EditScheduleNameOrMovie(Schedule schedule)
        {
            try
            {
                if (schedule != null)
                {
                    _cinema.Update(schedule);
                    _cinema.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool EditScheduleRoom(Schedule schedule)
        {
            try
            {
                //Saving the sits in a variable to be able to use the price later
                Sit[] sits = schedule.Sits.ToArray<Sit>();
                if (sits.Length != 0) 
                {
                    //Deleting the old schedule and adding a new one when they try to modify the 
                    DeleteSchedule(schedule);
                    AddSchedule(schedule, sits[0].Price);
                    _cinema.SaveChanges();                    
                }
                else
                {
                    DeleteSchedule(schedule);
                    AddSchedule(schedule, 0);
                    _cinema.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Schedule SearchScheduleById(int scheduleId)
        {
            try
            {
                Schedule? schedule = _cinema.Schedules.Find(scheduleId);
                if(schedule == null) 
                {
                    return null;
                }
                else 
                {
                    return schedule;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Schedule>? ScheduleList()
        {
            try
            {
                List<Schedule>? scheduleList = _cinema.Schedules.ToList();
                if (scheduleList == null)
                {
                    return null;
                }
                else
                {
                    return scheduleList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //This method will be to check in the Fatabase to confirm that there is no schedule on the system for the time, date and room that we need before adding one
        public List<Schedule>? CheckScheduleDateIsNotBussy(Schedule schedule)
        {
            try
            {
                string query = string.Format("USE [Cinema] {0}GO{0}SELECT * FROM [dbo].[Schedules] WHERE RoomId={3} AND DateStart between '{1}' and '{2}' OR DateEnd between '{1}' and '{2}'{0}GO", Environment.NewLine,schedule.StartDateTime, schedule.EndDateTime,schedule.RoomId);
                List<Schedule>? scheduleList = _cinema.Schedules.FromSqlRaw(query).ToList();
                if (scheduleList == null)
                {
                    return null;
                }
                else
                {
                    return scheduleList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public List<Schedule>? SearchSchedulesByDatesDAL(DateTime[] dates)
        {
            try
            {
                string query = string.Format("USE [Cinema] {0}GO{0}SELECT * FROM [dbo].[Schedules] WHERE DateStart between '{1}' and '{2}' OR DateEnd between '{1}' and '{2}'{0}GO", Environment.NewLine, dates[0], dates[1]);
                List<Schedule>? scheduleList = _cinema.Schedules.FromSqlRaw(query).ToList();
                if (scheduleList == null)
                {
                    return null;
                }
                else
                {
                    return scheduleList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Schedule>? SearchSchedulesByMovieDAL(Movie movie)
        {
            try
            {
                string query = string.Format("USE [Cinema] {0}GO{0}SELECT * FROM [dbo].[Schedules] WHERE MovieId={1}{0}GO", Environment.NewLine, movie.MovieId);
                List<Schedule>? scheduleList = _cinema.Schedules.FromSqlRaw(query).ToList();
                if (scheduleList == null)
                {
                    return null;
                }
                else
                {
                    return scheduleList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Schedule>? SearchSchedulesByRoomDAL(Room room)
        {
            DeleteOldSchedules();
            try
            {
                string query = string.Format("USE [Cinema] {0}GO{0}SELECT * FROM [dbo].[Schedules] WHERE RoomId={1}{0}GO", Environment.NewLine, room.RoomId);
                List<Schedule>? scheduleList = _cinema.Schedules.FromSqlRaw(query).ToList();
                if (scheduleList == null)
                {
                    return null;
                }
                else
                {
                    return scheduleList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
