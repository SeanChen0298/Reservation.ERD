using Microsoft.EntityFrameworkCore;
using Reservation.ERD.Model;

namespace Reservation.ERD.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ResourceEvent> ResourceEvents { get; set; }
        public DbSet<ResourceEventAttendee> ResourceEventAttendees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=reservation.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().ToTable("Resource");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<ResourceEvent>().ToTable("ResourceEvent");
            modelBuilder.Entity<ResourceEventAttendee>().ToTable("ResourceEventAttendee");
        }
    }
}
