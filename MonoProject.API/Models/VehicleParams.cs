using System;

namespace MonoProject.API.Models
{
    public class VehicleParams
    {
        public Guid Id { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string sortOrder { get; set; }
        public string sortyBy { get; set; }
        public string searchBy { get; set; }
        public string search { get; set; }
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
    }
}
