using Microsoft.Extensions.DependencyInjection;
using MonoProject.Service.Common;

namespace MonoProject.Service
{
    public static class DependencyBindings
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IVehicleMakeService, VehicleMakeService>();
            services.AddTransient<IVehicleModelService, VehicleModelService>();
            services.AddTransient<IVehicleOwnerService, VehicleOwnerService>();
            services.AddTransient<IVehicleRegistrationService, VehicleRegistrationService>();
            services.AddTransient<IVehicleEngineTypeService, VehicleEngineTypeService>();
        }
    }
}
