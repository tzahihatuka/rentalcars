using _00_DAL;
using _01_BOL;
using _02_BLL;
using _03_UIL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_UIL.Filter
{
    public class GetCarInventoryFilter
    {
        public static BOLCarInventory RetrieveCarInventory(CarInventoryModel carInventory)
        {
            BOLCarInventory newCarInventory = new BOLCarInventory();


            newCarInventory.CarsTypeID = RentTypeOfCars.ReturnCarTypeid(carInventory.ManufacturerName, carInventory.Model, carInventory.Gear);
            newCarInventory.BranchesID = RentBranches.ReturnBrancheid(carInventory.BranchesName);
            newCarInventory.IsProperForRent = carInventory.IsProperForRent;
            newCarInventory.UpdatedMileage = carInventory.UpdatedMileage;
            newCarInventory.VehicleNumber = carInventory.VehicleNumber;
            newCarInventory.VehiclePic = carInventory.VehiclePic;


            return newCarInventory;
        }

        internal static List<CarInventoryModel> ListRetrieveCarInventory(List<BOLCarInventory> carInventory, int from, int to)
        {
            try
            {
                List<CarInventoryModel> carsInventory = new List<CarInventoryModel>();
                BOLCarInventory[] arr = new BOLCarInventory[to - from];
                arr = carInventory.ToArray();
                for (int i = from; i < to; i++)
                {
                    CarsType a = RentTypeOfCars.ReturnCarType(arr[i].CarsTypeID);
                    carsInventory.Add(new CarInventoryModel
                    {
                        ManufacturerName = a.ManufacturerName,
                        Model = a.Model,
                        Gear = a.Gear,
                        DailyCost = a.DailyCost,
                        CostDayOverdue = a.CostDayOverdue,
                        ManufactureYear = a.ManufactureYear,
                        UpdatedMileage = arr[i].UpdatedMileage,
                        VehiclePic = arr[i].VehiclePic,
                        IsProperForRent = arr[i].IsProperForRent,
                        VehicleNumber = arr[i].VehicleNumber,
                        BranchesName = RentBranches.ReturnBrancheName(arr[i].BranchesID),
                    });
                }
                return carsInventory;


            }
            catch { }
            return null;
        }

        internal static CarInventoryModel ReturnCarInventory(BOLCarInventory value)
        {

            try
            {
                CarInventoryModel carsInventory = new CarInventoryModel();
               
                    CarsType a = RentTypeOfCars.ReturnCarType(value.CarsTypeID);

                carsInventory.ManufacturerName = a.ManufacturerName;
                carsInventory.Model = a.Model;
                carsInventory.Gear = a.Gear;
                carsInventory.DailyCost = a.DailyCost;
                carsInventory.CostDayOverdue = a.CostDayOverdue;
                carsInventory.ManufactureYear = a.ManufactureYear;
                carsInventory.UpdatedMileage = value.UpdatedMileage;
                carsInventory.VehiclePic = value.VehiclePic;
                carsInventory.IsProperForRent = value.IsProperForRent;
                carsInventory.VehicleNumber = value.VehicleNumber;
                carsInventory.BranchesName = RentBranches.ReturnBrancheName(value.BranchesID);

                return carsInventory;
            }
            catch { }
            return null;
        }

        internal static List<CarInventoryModel> ListRetrieveCarInventory1(List<BOLCarInventory> value, List<BOLOrder> orderlist)
        {
            try
            {
                List<CarInventoryModel> carsInventory = new List<CarInventoryModel>();
                for (int i = 0; i < value.Count; i++)
                {
                    CarsType a = RentTypeOfCars.ReturnCarType(value[i].CarsTypeID);
                    carsInventory.Add(new CarInventoryModel
                    {
                        ManufacturerName = a.ManufacturerName,
                        Model = a.Model,
                        Gear = a.Gear,
                        DailyCost = a.DailyCost,
                        CostDayOverdue = a.CostDayOverdue,
                        ManufactureYear = a.ManufactureYear,
                        UpdatedMileage = value[i].UpdatedMileage,
                        VehiclePic = value[i].VehiclePic,
                        IsProperForRent = value[i].IsProperForRent,
                        VehicleNumber = value[i].VehicleNumber,
                        BranchesName = RentBranches.ReturnBrancheName(value[i].BranchesID),
                        StartDate = orderlist[i].StartDate,
                        endDate = orderlist[i].ReturnDate,
                    });
                }
                return carsInventory;
            }
            catch { }
            return null;
        }

     

        internal static List<CarInventoryModel> ListRetrieveFilteredCarInventory(List<BOLCarInventory> carInventory, string company, string gear, string model, string openText, DateTime? year)
        {
            try
            {

                List<CarInventoryModel> carsInventory = new List<CarInventoryModel>();
                BOLCarInventory[] arr = new BOLCarInventory[carInventory.Count];


                arr = carInventory.ToArray();
                for (int i = 0; i < carInventory.Count; i++)
                {
                    CarsType a = RentTypeOfCars.ReturnCarType(arr[i].CarsTypeID);

                    carsInventory.Add(new CarInventoryModel
                    {
                        ManufacturerName = a.ManufacturerName,
                        Model = a.Model,
                        Gear = a.Gear,
                        ManufactureYear = a.ManufactureYear,
                        UpdatedMileage = arr[i].UpdatedMileage,
                        VehiclePic = arr[i].VehiclePic,
                        IsProperForRent = arr[i].IsProperForRent,
                        VehicleNumber = arr[i].VehicleNumber,
                        BranchesName = RentBranches.ReturnBrancheName(arr[i].BranchesID),
                    });

                }
                carsInventory = getFlitredList(carsInventory, company, gear, model, openText, year);
                return carsInventory;


            }
            catch { }
            return null;
        }

        private static List<CarInventoryModel> getFlitredList(List<CarInventoryModel> carInventory, string company, string gear, string model, string openText, DateTime? year)
        {
            try
            {
                carInventory = company != "null" ? carInventory.Where(u => u.ManufacturerName == company).ToList() : carInventory;
            }
            catch { }
            try
            {
                carInventory = gear != "null" ? carInventory.Where(u => u.Gear.TrimEnd() == gear).ToList() : carInventory;
            }
            catch { }
            try
            {
                carInventory = model != "null" ? carInventory.Where(u => u.Model == model).ToList() : carInventory;
            }
            catch { }
            try
            {
                carInventory = openText != "null" ? carInventory.Where(u => u.ManufacturerName.Contains(openText) ||
                u.Gear.Contains(openText) || u.Model.Contains(openText) ||
                u.ManufactureYear.ToString().Contains(openText) || u.VehicleNumber.ToString().Contains(openText) ||
                u.UpdatedMileage.ToString().Contains(openText) || u.BranchesName.Contains(openText)).ToList() : carInventory;
            }
            catch { }
            try
            {
                carInventory = year != null ? carInventory.Where(u => u.ManufactureYear == year).ToList() : carInventory;
            }
            catch { }
            return carInventory;
        }
    }
}