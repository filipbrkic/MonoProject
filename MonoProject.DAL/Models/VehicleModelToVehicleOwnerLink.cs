using System;
using System.Collections.Generic;

namespace MonoProject.DAL.Models
{
    public class VehicleModelToVehicleOwnerLink
    {
        public Guid ModelId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid RegistrationId { get; set; }

        public List<VehicleModel> VehicleModels { get; set; }
        public VehicleRegistration VehicleRegistration { get; set; }
        public List<VehicleOwner> VehicleOwners { get; set; }
    }
}
