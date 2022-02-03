using System;

namespace MonoProject.API.Models
{
    public class VehicleOwnerDVO
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
