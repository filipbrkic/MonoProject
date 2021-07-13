using System;
using System.ComponentModel.DataAnnotations;

namespace MonoProject.MVC.Models
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }
    }
}
