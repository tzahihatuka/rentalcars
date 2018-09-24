
using System.Collections.Generic;
namespace _01_BOL
{
    public class CarInventory
    {
       public int CarsTypeID { get; set; }
        public int UpdatedMileage { get; set; }
        public string VehiclePic { get; set; }
        public bool IsProperForRent { get; set; }
        public bool IsAvailableForRent { get; set; }
        public int VehicleNumber { get; set; }
        public int BranchesID { get; set; }

        public List<CarInventory> carList { get; set; }
    }
}
