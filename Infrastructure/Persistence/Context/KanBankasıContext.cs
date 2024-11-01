using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class KanBankasıContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=KanBankası;User=TestUser;Password=321321;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation>()
                .HasOne(d => d.User)
                .WithMany(u => u.Donations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Veya DeleteBehavior.Restrict
            modelBuilder.Entity<Request>()
           .HasOne(r => r.User)
           .WithMany(u => u.Requests)
           .HasForeignKey(r => r.UserId)
           .OnDelete(DeleteBehavior.NoAction);
        }


        public DbSet<BloodStock> BloodStocks { get; set;}
        public DbSet<BloodType> BloodTypes { get; set;}
        public DbSet<Donation> Donations { get; set;}
        public DbSet<Request> Requests { get; set;}
        public DbSet<Role> Roles { get; set;}
        public DbSet<User> Users { get; set;}
    }
}
