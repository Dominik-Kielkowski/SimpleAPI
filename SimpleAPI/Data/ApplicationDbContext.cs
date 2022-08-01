using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;

namespace SimpleAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Occupation> Occupations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(r => r.Name).IsRequired();

            modelBuilder.Entity<Occupation>().Property(r => r.OccupationName).IsRequired();

            modelBuilder.Entity<Occupation>().HasData(
                new Occupation
                {
                    OccupationId = 1,
                    OccupationName = "Doctor"
                },
                new Occupation
                {
                    OccupationId = 2,
                    OccupationName = "Firefighter"
                },
                new Occupation
                {
                    OccupationId = 3,
                    OccupationName = "Policeman"
                }
                );
        }
    }
}
