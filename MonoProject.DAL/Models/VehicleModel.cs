using System;
using System.Collections.Generic;

namespace MonoProject.DAL.Models
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid EngineTypeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public VehicleEngineType VehicleEngineType { get; set; }
        public List<VehicleModelToVehicleOwnerLink> VehicleModelToVehicleOwnerLinks { get; set; }
    }
}
