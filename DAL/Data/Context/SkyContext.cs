using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SkyContext:DbContext
    {
        
        public SkyContext(DbContextOptions<SkyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<User>()
                .HasOne(p => p.Country)
                .WithMany(p => p.Users);
            modelBuilder.Entity<UserCountry>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Country);
            modelBuilder.Entity<EmailConfirm>()
                .HasOne(p => p.User)
                .WithOne(p => p.EmailConfirm);*/
            //Seeding 
            modelBuilder.Entity<UserCountry>().HasData(
                new UserCountry { UserCountryId = 1, Country = "Afghanistan", DailCode = 93 },
                new UserCountry { UserCountryId = 2, Country = "Aland Islands", DailCode = 358 },
                new UserCountry { UserCountryId = 3, Country = "Albania", DailCode = 355 },
                new UserCountry { UserCountryId = 4, Country = "Algeria", DailCode = 213 },
                new UserCountry { UserCountryId = 5, Country = "AmericanSamoa", DailCode = 1684 },
                new UserCountry { UserCountryId = 6, Country = "Andorra", DailCode = 376 },
                new UserCountry { UserCountryId = 7, Country = "Angola", DailCode = 244 },
                new UserCountry { UserCountryId = 8, Country = "Anguilla", DailCode = 1264 },
                new UserCountry { UserCountryId = 9, Country = "Antarctica", DailCode = 672 }
                );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Ahmed",LastName = "Mohamed",Phone = "010202020",Email="ahmedmo@gmail.com",Password = "123456",ConfirmPassword="123456",UserCountryId = 1},
                new User { Id = 2, FirstName = "mohamed", LastName = "Mohamed", Phone = "010202020", Email = "ahmedmo@gmail.com", Password = "123456", ConfirmPassword = "123456",UserCountryId = 2 },
                new User { Id = 3, FirstName = "sara", LastName = "Mohamed", Phone = "010202020", Email = "ahmedmo@gmail.com", Password = "123456", ConfirmPassword = "123456",UserCountryId =3 }
                );

            modelBuilder.Entity<UserCountry>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Country)
                .HasForeignKey(P=>P.UserCountryId);
            
        }


        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserCountry> UserCountries { get; set; } = null!;
        public DbSet<EmailConfirm> EmailConfirms { get; set; } = null!;
    }
}
