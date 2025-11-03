using Microsoft.EntityFrameworkCore;
using SPMDemo.Models.Entities;

namespace SPMDemo.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public DbSet<PointOfInterest> PointOfInterests { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
    }
}
