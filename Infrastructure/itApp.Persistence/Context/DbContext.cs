using grammerGame.Domain.Entities;
using grammerGame.Domain.Entities.Common;
using grammerGame.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace grammerGame.Persistence.Context
{
    public class GrammerGameDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public GrammerGameDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.GameProgress)
                .WithOne(g => g.AppUser)
                .HasForeignKey<GameProgress>(g => g.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.UserPreferences)
                .WithOne(u => u.AppUser)
                .HasForeignKey<UserPreferences>(u => u.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.SocialData)
                .WithOne(s => s.AppUser)
                .HasForeignKey<SocialData>(s => s.AppUserId);
        }


    }
 }

















