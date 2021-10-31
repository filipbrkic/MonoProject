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
            modelBuilder.Entity<VehicleModel>().HasOne(m => m.VehicleMake).WithMany(o => o.VehicleModels).HasForeignKey(e => e.MakeId);
            modelBuilder.Entity<VehicleEngineType>().HasOne(m => m.VehicleModel).WithOne(o => o.VehicleEngineType).HasForeignKey<VehicleModel>(e => e.EngineTypeId);
            modelBuilder.Entity<VehicleModelToVehicleOwnerLink>().HasKey(x => new { x.OwnerId, x.ModelId, x.RegistrationId });
            modelBuilder.Entity<VehicleModelToVehicleOwnerLink>().HasOne(m => m.VehicleModel).WithMany(o => o.VehicleModelToVehicleOwnerLinks)
                .HasForeignKey(x => x.ModelId);
         /*   modelBuilder.Entity<VehicleModelToVehicleOwnerLink>().HasOne<VehicleOwner>(m => m.VehicleOwner).WithMany(m => m.VehicleModelToVehicleOwnerLinks)
                .HasForeignKey(m => m.OwnerId);     */
            modelBuilder.Entity<VehicleRegistration>().HasOne(m => m.VehicleModelToVehicleOwnerLink).WithOne(o => o.VehicleRegistration)
                .HasForeignKey<VehicleModelToVehicleOwnerLink>(x => x.RegistrationId);
            modelBuilder.Entity<VehicleOwner>().HasMany(m => m.VehicleModelToVehicleOwnerLinks).WithOne(o => o.VehicleOwner).HasForeignKey(x => x.OwnerId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
