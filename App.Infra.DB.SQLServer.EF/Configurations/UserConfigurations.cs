using App.Domain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class UserConfigurations
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            //Seed Users
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = 1,
                    FullName = "Navid Jafarzdeh",
                    UserName = "navid@gmail.com",
                    NormalizedUserName ="NAVID@GMAIL.COM",
                    Email = "navid@gmail.com",
                    NormalizedEmail = "NAVID@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser()
                {
                    Id = 2,
                    FullName = "Ali Karimi",
                    UserName = "Ali@gmail.com",
                    NormalizedUserName = "ALI@GMAIL.COM",
                    Email = "Ali@gmail.com",
                    NormalizedEmail = "ALI@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "09377507920",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser()
                {
                    Id = 3,
                    FullName = "Sahar Akbari",
                    UserName = "Sahar@gmail.com",
                    NormalizedUserName = "SAHAR@GMAIL.COM",
                    Email = "Sahar@gmail.com",
                    NormalizedEmail = "SAHAR@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "09377507920",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser()
                {
                    Id = 4,
                    FullName = "Maryam Asadi",
                    UserName = "Maryam@gmail.com",
                    NormalizedUserName = "MARYAM@GMAIL.COM",
                    Email = "Maryam@gmail.com",
                    NormalizedEmail = "MARYAM@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "09377507920",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "4321");

                modelBuilder.Entity<ApplicationUser>().HasData(user);
            }

            //Seed Roles
            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Expert", NormalizedName = "EXPERT" },
                new IdentityRole<int>() { Id = 3, Name = "Customer", NormalizedName = "CUSTOMER" }
                );


            //Seed Role for Users
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int> { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int> { RoleId = 2, UserId = 3 },
                new IdentityUserRole<int> { RoleId = 3, UserId = 4 }
                );
        }
    }
}
