using Microsoft.Extensions.DependencyInjection;
using MonoProject.DAL.Data;
using MonoProject.Repository.Common;

namespace MonoProject.Repository
{
    public static class DependencyBindings
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
            services.AddTransient<IVehicleOwnerRepository, VehicleOwnerRepository>();
            services.AddTransient<IVehicleRegistrationRepository, VehicleRegistrationRepository>();
            services.AddTransient<IVehicleEngineTypeRepository, VehicleEngineTypeRepository>();
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IVehicleModelToVehicleOwnerLinkRepository, VehicleModelToVehicleOwnerLinkRepository>();
            services.AddDbContext<VehicleDbContext>(ServiceLifetime.Transient);
        }
    }
}
