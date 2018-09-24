using System;
using System.Collections.Generic;

namespace _01_BOL
{
    public class BOLCarType
    {
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public decimal DailyCost { get; set; }
        public decimal CostDayOverdue { get; set; }
        public DateTime ManufactureYear { get; set; }
        public string Gear { get; set; }

        public List<BOLCarType> CarTypeList { get; set; }
    }
}
