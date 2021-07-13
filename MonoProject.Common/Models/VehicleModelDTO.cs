using System;

namespace MonoProject.Common.Models
{
    public class VehicleModelDTO
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string MakeName { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
