using System;

namespace MonoProject.API.Models
{
    public class EngineTypeParams
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Abrv { get; set; }
        public string SortOrder { get; set; }
        public string SortyBy { get; set; }
        public string SearchBy { get; set; }
        public string Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
