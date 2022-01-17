using System;

namespace MonoProject.Common.Models
{
    public class VehicleOwnerDTO
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid ModelId { get; set; }

        public Guid RegistrationId { get; set; }
        public string RegistrationNumber { get; set; }

        public Guid MakeId { get; set; }
        public Guid EngineTypeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

    }
}
