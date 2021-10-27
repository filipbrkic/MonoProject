using System;

namespace MonoProject.API.Models
{
    public class RegistrationParams
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string SortOrder { get; set; }
        public string SortyBy { get; set; }
        public string SearchBy { get; set; }
        public string Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
