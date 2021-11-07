using System;

namespace MonoProject.API.Models
{
    public class OwnerParams
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid ModelId { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
