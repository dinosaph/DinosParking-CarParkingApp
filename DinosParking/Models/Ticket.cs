using System;
using System.ComponentModel.DataAnnotations;

namespace DinosParking.Models
{
    public class Ticket
    {
        [Display(Name = "Ticket ID")]
        public int Id { get; set; }
        [Display(Name = "Car Number")]
        public String Car_Number { get; set; }
        [Display(Name = "Time In")]
        public DateTime Time_In { get; set; }
        [Display(Name = "Barcode")]
        public String? BarCode { get; set; }
        [Display(Name = "Time Out")]
        public DateTime? Time_Out { get; set; }
        [Display(Name = "Total Fee")]
        public int? Total_Fee { get; set; }
    }
}
