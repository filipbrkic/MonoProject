using System;

namespace MonoProject.Models
{
    public class VehicleModelDTO
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid EngineTypeId { get; set; }
    }
}
