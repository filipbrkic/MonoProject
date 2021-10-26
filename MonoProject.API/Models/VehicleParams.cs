using System;

namespace MonoProject.API.Models
{
    public class VehicleParams
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public Guid EngineTypeId { get; set; }
        public Guid ModelId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid RegistrationId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Abrv { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SortOrder { get; set; }
        public string SortyBy { get; set; }
        public string SearchBy { get; set; }
        public string Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
