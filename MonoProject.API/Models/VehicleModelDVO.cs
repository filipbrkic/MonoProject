using System;

namespace MonoProject.API.Models
{
    public class VehicleModelDVO
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid EngineTypeId { get; set; }
    }
}
