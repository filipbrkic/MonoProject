using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient<IVehicleModelToVehicleOwnerLinkRepository, VehicleModelToVehicleOwnerLinkRepository>();
        }
    }
}
