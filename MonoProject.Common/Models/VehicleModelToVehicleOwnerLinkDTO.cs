using System;

namespace MonoProject.Common.Models
{
    public class VehicleModelToVehicleOwnerLinkDTO
    {
        public Guid ModelId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid RegistrationId { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid MakeId { get; set; }
        public Guid EngineTypeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
