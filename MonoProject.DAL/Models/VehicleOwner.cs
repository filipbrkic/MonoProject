using System;
using System.Collections.Generic;

namespace MonoProject.DAL.Models
{
    public class VehicleOwner
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<VehicleModelToVehicleOwnerLink> vehicleModelToVehicleOwnerLinks { get; set; }
    }
}
