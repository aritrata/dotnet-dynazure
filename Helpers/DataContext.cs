using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            //options.UseInMemoryDatabase("TestDb");
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<VaccinationDetail> CustVaccinationDetails { get; set; }
    }
}