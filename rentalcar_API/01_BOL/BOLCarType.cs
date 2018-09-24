using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL
{
    public class BOLCarType
    {
        [Required]
        [StringLength(40, MinimumLength=3)]
        public string ManufacturerName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Model { get; set; }
        [Required]
        public decimal DailyCost { get; set; }
        
        private decimal myVar;

        public decimal CostDayOverdue
        {
            get { return DailyCost + (20 * DailyCost / 100); }
            set { myVar = value + (20 * DailyCost / 100); }
        }
        [Required]
        public DateTime ManufactureYear { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Gear { get; set; }
        

    }
}
