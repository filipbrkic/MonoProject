using System;

namespace MonoProject.Common.Models
{
    public class VehicleModelToVehicleOwnerLinkDTO
    {
        public Guid ModelId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid RegistrationId { get; set; }
    }
}
