using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03_UIL.Models
{
    public class OrderModel
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int VehicleNumber { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public DateTime? oldStart { get; set; }
    }
}