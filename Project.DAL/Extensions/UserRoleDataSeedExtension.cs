using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extensions
{
    public static class UserRoleDataSeedExtension
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            AppRole appRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            modelBuilder.Entity<AppRole>().HasData(appRole);

            PasswordHasher<AppUser> passwordHasher = new();

            AppUser user = new()
            {
                Id = 1,
                UserName = "metin",
                Email = "metinmustafaaltintas@gmail.com",
                NormalizedEmail = "METINMUSTAFAALTINTAS@GMAIL.COM",
                NormalizedUserName = "METIN",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Metin57.")
            };

            modelBuilder.Entity<AppUser>().HasData(user);

            modelBuilder.Entity<AppUserRole>().HasData(new AppUserRole
            {
                RoleId = appRole.Id,
                UserId = user.Id
            });

        }
    }
}
