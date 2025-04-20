using Microsoft.EntityFrameworkCore;
using T_Camps.ViewModels;

namespace T_Camps.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // Check and create the database if it doesn't exist
            //Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
    }
}
