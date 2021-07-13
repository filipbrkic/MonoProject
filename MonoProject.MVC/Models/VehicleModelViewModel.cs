using System;
using System.ComponentModel.DataAnnotations;

namespace MonoProject.MVC.Models
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        [Display(Name= "Abbreviation")]
        public string Abrv { get; set; }
    }
}
