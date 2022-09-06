using Microsoft.EntityFrameworkCore;
using SimpleAPI.Database.Models;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(r => r.Email).IsRequired();

            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired();

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

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "User"
                },
                new Role
                {
                    Id = 2,
                    Name = "Manager"
                },
                new Role
                {
                    Id = 3,
                    Name = "Admin"
                }
                );
        }
    }
}
