using System;

namespace MonoProject.DAL.Models
{
    public class VehicleRegistration
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }

        public VehicleModelToVehicleOwnerLink vehicleModelToVehicleOwnerLink { get; set; }
    }
}
