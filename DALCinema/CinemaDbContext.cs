
using Microsoft.EntityFrameworkCore;

namespace DALCinema
{
    public class CinemaDbContext : DbContext 
    {
        public CinemaDbContext( DbContextOptions<CinemaDbContext> options) : base(options)
        {
                
        }
        public DbSet<ParentalGuidance> ParentalGuidances { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Sit> Sits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentalGuidance>().ToTable("ParentalGuidance");
        }
    }
}
