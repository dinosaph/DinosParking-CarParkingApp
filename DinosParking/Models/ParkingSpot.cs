using System;
using System.ComponentModel.DataAnnotations;

namespace DinosParking.Models
{
    public class ParkingSpot
    {
        [Display(Name = "Parking ID")]
        public int Id { get; set; }
        [Display(Name = "Occupant ID")]
        public int? Occupant_Id { get; set; }
    }
}
