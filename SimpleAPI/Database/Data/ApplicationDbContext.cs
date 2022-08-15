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

            modelBuilder.Entity<Occupation>().Property(r => r.Name).IsRequired();

            modelBuilder.Entity<Occupation>().HasData(
                new Occupation
                {
                    Id = 1,
                    Name = "Doctor"
                },
                new Occupation
                {
                    Id = 2,
                    Name = "Firefighter"
                },
                new Occupation
                {
                    Id = 3,
                    Name = "Policeman"
                }
                );
        }
    }
}
