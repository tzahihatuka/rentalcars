using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
    public class BOLCarInventory
    {
        [Required]
        public int CarsTypeID { get; set; }
        [Required]
        public int UpdatedMileage { get; set; }
        [Required]
        public bool IsProperForRent { get; set; }
        [Required]
        public int VehicleNumber { get; set; }
        [Required]
        public int BranchesID { get; set; }
        [Required]
        public string VehiclePic { get; set; }

    }
}
