﻿using System;

namespace MonoProject.Models
{
    public class VehicleOwnerDTO
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
