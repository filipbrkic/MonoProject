﻿
using Microsoft.EntityFrameworkCore;
using MonoProject.DAL.Models;

namespace MonoProject.DAL.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
        }

        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().HasOne(m => m.VehicleMake).WithMany(o => o.VehicleModels);
            base.OnModelCreating(modelBuilder);
        }
    }
}