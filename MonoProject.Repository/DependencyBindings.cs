using Microsoft.Extensions.DependencyInjection;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public static class DependencyBindings
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
        }
    }
}
