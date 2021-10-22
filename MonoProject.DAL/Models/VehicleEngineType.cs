using System;

namespace MonoProject.DAL.Models
{
    public class VehicleEngineType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Abrv { get; set; }
        public VehicleModel VehicleModel { get; set; }
    }
}
