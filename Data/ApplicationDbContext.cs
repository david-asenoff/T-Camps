using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using T_Camps.ViewModels;


namespace T_Camps.Data
{
   public class ApplicationDbContext : DbContext
   {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
       {
       }

       public DbSet<ClientViewModel> Clients { get; set; }
   }
}