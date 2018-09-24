using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
    public class BOLOrder
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int VehiclesID { get; set; }

        public DateTime? ActualReturnDate { get; set; }

    }
}
