using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03_UIL.Models
{
    public class CarInventoryModel
    {
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Gear { get; set; }
        [Required]
        public string ManufacturerName { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime ManufactureYear { get; set; }
        [Required]
        public string BranchesName { get; set; }
        [Required]
        public int UpdatedMileage { get; set; }
        [Required]
        public bool IsProperForRent { get; set; }
        [Required]
        public int VehicleNumber { get; set; }
        [Required]
        public decimal? DailyCost { get; set; }
        [Required]
        public decimal? CostDayOverdue { get; set; }
        [Required]
        public string VehiclePic { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}