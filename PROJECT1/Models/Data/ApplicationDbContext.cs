using Microsoft.EntityFrameworkCore;
using PROJECT1.Models;

namespace PROJECT1.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Booking> Booking { get; set; } // Existing DbSet for Booking
        public DbSet<Event> Events { get; set; } // DbSet for EventModel (Ensure this is here)
        public DbSet<Venue> Venues { get; set; } // Existing DbSet for Venue
    }
}