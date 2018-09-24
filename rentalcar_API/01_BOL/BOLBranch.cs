using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL
{
   public class BOLBranch
    {
        [Required]
        [StringLength(40, MinimumLength = 10)]
        public string Address { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string BranchesName { get; set; }
        [Required]
        public decimal Latitude { get; set; }
    }
}
