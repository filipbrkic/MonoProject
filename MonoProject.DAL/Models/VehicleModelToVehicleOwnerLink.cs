using System;

namespace MonoProject.DAL.Models
{
    public class VehicleModelToVehicleOwnerLink
    {
        public Guid? ModelId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? RegistrationId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public VehicleRegistration VehicleRegistration { get; set; }
        public VehicleOwner VehicleOwner { get; set; }
    }
}
