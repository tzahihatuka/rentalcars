using System;
using _01_BOL;
using System.Collections.Generic;
using System.Linq;
using _00_DAL;

namespace _02_BLL
{
    internal class ValidateCarInput: RentTypeOfCars
    {
        internal static CarsType IsExist(BOLCarType carType)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                CarsType carTipe = ef.CarsTypes.FirstOrDefault(u => u.ManufacturerName == carType.ManufacturerName &&
            u.Model == carType.Model &&
            u.ManufactureYear == carType.ManufactureYear && u.Gear == carType.Gear&&
            u.DailyCost==carType.DailyCost);
                
                if (carTipe != null)
                {
                    return carTipe;
                }
                else
                {
                    return carTipe;
                }
            }
        }
    }
}