using _01_BOL;
using _00_DAL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_BLL
{
    public class RentTypeOfCars
    {

        public static List<string> GetTypeNames()
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<string> typeNames = ef.CarsTypes.Select(m => m.ManufacturerName).Distinct().ToList();
                    return typeNames;
                }
            }
            catch
            {
                return null;
            }

        }
        public static List<DateTime> GetTypeYear()
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<DateTime> typeNames = ef.CarsTypes.Select(m => m.ManufactureYear).Distinct().ToList();
                    return typeNames;
                }
            }
            catch
            {
                return null;
            }

        }

        public static BOLCarType GetCarsTypeFrom_db(string name, string model, string gear)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    CarsType typeModel = ef.CarsTypes.FirstOrDefault(u => u.ManufacturerName == name&&u.Model==model&&u.Gear==gear);
                    BOLCarType a = new BOLCarType
                    {
                        ManufacturerName = typeModel.ManufacturerName,
                        Model = typeModel.Model,
                        DailyCost = typeModel.DailyCost,
                        CostDayOverdue = typeModel.CostDayOverdue,
                        ManufactureYear = typeModel.ManufactureYear,
                        Gear = typeModel.Gear
                    };
                    return a;
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetTypeModel(string TypeName)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<string> typeModel = ef.CarsTypes.Where(u => u.ManufacturerName == TypeName).Select(m => m.Model).Distinct().ToList();
                    return typeModel;
                }
            }
            catch
            {
                return null;
            }

        }

        public static List<string> GetTypeGear()
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<string> typeNames = ef.CarsTypes.Select(m => m.Gear).Distinct().ToList();
                    return typeNames;
                }
            }
            catch
            {
                return null;
            }

        }

        public static List<BOLCarType> GetDistinctName()
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<BOLCarType> typeModel = new List<BOLCarType>();
                    List<int> typeid = ef.VehicleInventories.Select(m => m.CarsTypeID).ToList();
                    foreach (var item in typeid)
                    {
                        CarsType cartype = ef.CarsTypes.FirstOrDefault(u => u.CarTypeID == item);
                        typeModel.Add(new BOLCarType
                        {
                            ManufacturerName = cartype.ManufacturerName,
                            Model = cartype.Model,
                            DailyCost = cartype.DailyCost,
                            CostDayOverdue = cartype.CostDayOverdue,
                            ManufactureYear = cartype.ManufactureYear,
                            Gear = cartype.Gear
                        });
                    }

                    return typeModel;
                }
            }
            catch
            {
                return null;
            }
        }

        public static decimal getDaylyCost(int CarTypeID)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                CarsType getCost = ef.CarsTypes.FirstOrDefault(u => u.CarTypeID == CarTypeID);
                return getCost.DailyCost;
            }
        }

        public static List<BOLCarType> GetCarsTypeFrom_db(string typeName)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {

                    List<BOLCarType> CarTypeList = new List<BOLCarType>();
                    List<CarsType> carType = ef.CarsTypes.Where(u => u.ManufacturerName == typeName).ToList();
                    foreach (var item in carType)
                    {
                        CarTypeList.Add(new BOLCarType
                        {
                            ManufacturerName = item.ManufacturerName,
                            Model = item.Model,
                            DailyCost = item.DailyCost,
                            CostDayOverdue = item.CostDayOverdue,
                            ManufactureYear = item.ManufactureYear,
                            Gear = item.Gear
                        });
                    }
                    return CarTypeList;
                }

            }
            catch { }
            return null;
        }



        public static string AddCarTypeTo_db(BOLCarType carType)
        {
            try
            {
                CarsType isExist = ValidateCarInput.IsExist(carType);
                if (isExist == null)
                {
                    using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                    {

                        ef.CarsTypes.Add(new CarsType
                        {

                            ManufacturerName = carType.ManufacturerName,
                            Model = carType.Model,
                            DailyCost = carType.DailyCost,
                            CostDayOverdue = carType.CostDayOverdue,
                            ManufactureYear = carType.ManufactureYear,
                            Gear = carType.Gear
                        });
                        ef.SaveChanges();
                        return "OK";
                    }
                }
                else
                {
                    throw new InvalidOperationException($"this car type is already exist please change  the values and try again");
                }
            }
            catch 
            {
                return "this car type is already exist please change  the values and try again";
            }
        }



        public static string UpDataCarTypeTo_db(BOLCarType oldCarType, BOLCarType newCarType)
        {
            CarsType isExist = ValidateCarInput.IsExist(oldCarType);
            try
            {
                if (isExist != null)
                {
                    using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                    {
                        CarsType isTheNewExist = ValidateCarInput.IsExist(newCarType);
                        if (isTheNewExist == null)
                        {
                            CarsType dbUser = ef.CarsTypes.FirstOrDefault(u => u.CarTypeID == isExist.CarTypeID);

                            dbUser.ManufacturerName = newCarType.ManufacturerName;
                            dbUser.Model = newCarType.Model;
                            dbUser.DailyCost = newCarType.DailyCost;
                            dbUser.ManufactureYear = newCarType.ManufactureYear;
                            dbUser.Gear = newCarType.Gear;

                            ef.SaveChanges();
                            return "Ok";
                        }
                        else
                        {
                            return "this car type is already exist please change  the values and try again";
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException($"this car type is not exist please change the values and try again");
                }
            }
            catch 
            {
                return "this car type is not exist please change the values and try again";
            }
        }


        public static void deleteFrom_db(string ManufacturerName, string Model, string Gear, DateTime ManufactureYear, decimal DailyCost, decimal CostDayOverdue)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    CarsType isExist = ef.CarsTypes.FirstOrDefault(u => u.ManufacturerName == ManufacturerName && u.ManufactureYear == ManufactureYear && u.Model == Model && u.Gear == Gear &&
                      u.DailyCost == DailyCost && u.CostDayOverdue == CostDayOverdue);
                    if (isExist != null)
                    {
                        ef.CarsTypes.Remove(isExist);
                        ef.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car type is not exist please change the values and try again");

                    }
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }


        public static int ReturnCarTypeid(string manufacturerName, string model, string gear)
        {

            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    CarsType isExist = ef.CarsTypes.FirstOrDefault(u => u.ManufacturerName == manufacturerName && u.Model == model && u.Gear == gear);
                    if (isExist != null)
                    {

                        return isExist.CarTypeID;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car type is not exist please change the values and try again");

                    }
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }


        public static CarsType ReturnCarType(int carsTypeID)
        {

            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    CarsType isExist = ef.CarsTypes.FirstOrDefault(u => u.CarTypeID == carsTypeID);
                    if (isExist != null)
                    {
                        CarsType carType = isExist;

                        return carType;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car type is not exist please change the values and try again");

                    }
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }

    }
}


