using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerRepository
{
    public class AppDbContext : IdentityDbContext<Staff,AppRole,int>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        //public DbSet<Staff> Admins { get;  set; }
        public DbSet<Travel> Travels { get;  set; }
        public DbSet<Status> Statuses { get;  set; }
        public DbSet<Staff> Staffs { get;  set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>()
           .HasMany(s => s.Travels)
           .WithOne(t => t.Staff)
           .HasForeignKey(t => t.StaffId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Staff>()
            .HasOne(s => s.Admin)
            .WithMany(a => a.staffs)
            .HasForeignKey(s => s.AdminId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Travel>()
                .HasOne(t => t.Admin)
                .WithMany(a => a.travelAdmins)
                .HasForeignKey(t => t.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Travel>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Travels)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }

	}
}
