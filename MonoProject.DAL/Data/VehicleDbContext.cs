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
        public DbSet<VehicleEngineType> VehicleEngineTypes { get; set; }
        public DbSet<VehicleModelToVehicleOwnerLink> VehicleModelToVehicleOwnerLinks { get; set; }
        public DbSet<VehicleOwner> VehicleOwners { get; set; }
        public DbSet<VehicleRegistration> VehicleRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().HasOne(m => m.VehicleMake).WithMany(o => o.VehicleModels);
            modelBuilder.Entity<VehicleModel>().HasOne(m => m.VehicleEngineType).WithOne(o => o.VehicleModel).HasForeignKey<VehicleEngineType>(e => e.Id);
            modelBuilder.Entity<VehicleModelToVehicleOwnerLink>().HasKey(x => new { x.OwnerId, x.ModelId, x.RegistrationId });
            modelBuilder.Entity<VehicleModelToVehicleOwnerLink>().HasOne(m => m.VehicleModel).WithMany(o => o.VehicleModelToVehicleOwnerLinks)
                .HasForeignKey(x => x.ModelId);
            modelBuilder.Entity<VehicleModelToVehicleOwnerLink>().HasOne(m => m.VehicleOwner).WithMany(m => m.VehicleModelToVehicleOwnerLinks)
                .HasForeignKey(m => m.OwnerId);
            modelBuilder.Entity<VehicleRegistration>().HasOne(m => m.vehicleModelToVehicleOwnerLink).WithOne(o => o.VehicleRegistration)
                .HasForeignKey<VehicleModelToVehicleOwnerLink>(x => x.RegistrationId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
