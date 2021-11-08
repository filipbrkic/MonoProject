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

        public string SortOrder { get; set; }
        public string SortyBy { get; set; }
        public string SearchBy { get; set; }
        public string Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
