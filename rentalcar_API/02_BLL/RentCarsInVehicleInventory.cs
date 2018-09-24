using _00_DAL;
using _01_BOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BLL
{
    public class RentCarsInVehicleInventory
    {




        public static List<BOLCarInventory> GetCarFrom_db()
        {
            try
            {
                List<BOLCarInventory> carsInventory = new List<BOLCarInventory>();

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    foreach (var item in ef.VehicleInventories.ToList())
                    {
                        if (item.IsProperForRent)
                        {
                            carsInventory.Add(new BOLCarInventory
                            {
                                CarsTypeID = item.CarsTypeID,
                                UpdatedMileage = item.UpdatedMileage,
                                VehiclePic = item.VehiclePic,
                                IsProperForRent = item.IsProperForRent,
                                VehicleNumber = item.VehicleNumber,
                                BranchesID = item.BranchesID
                            });
                        }
                    }
                    return carsInventory;
                }

            }
            catch { }
            return null;
        }

        public static BOLCarInventory GetCarFrom_db(int carNumber)
        {
            try
            {
                BOLCarInventory carsInventory = new BOLCarInventory();

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    VehicleInventory orderedCar = ef.VehicleInventories.FirstOrDefault(u => u.VehicleNumber == carNumber);

                    carsInventory.CarsTypeID = orderedCar.CarsTypeID;
                    carsInventory.UpdatedMileage = orderedCar.UpdatedMileage;
                    carsInventory.VehiclePic = orderedCar.VehiclePic;
                    carsInventory.IsProperForRent = orderedCar.IsProperForRent;
                    carsInventory.VehicleNumber = orderedCar.VehicleNumber;
                    carsInventory.BranchesID = orderedCar.BranchesID;

                    return carsInventory;
                }

            }
            catch { }
            return null;
        }


        public static List<BOLCarInventory> GetCarFrom_db(List<BOLOrder> orderlist)
        {
            List<BOLCarInventory> carsInventory = new List<BOLCarInventory>();
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                foreach (var item in orderlist)
                {
                    VehicleInventory orderedCar = ef.VehicleInventories.FirstOrDefault(u => u.VehiclesID == item.VehiclesID);

                    carsInventory.Add(new BOLCarInventory
                    {
                        CarsTypeID = orderedCar.CarsTypeID,
                        UpdatedMileage = orderedCar.UpdatedMileage,
                        VehiclePic = orderedCar.VehiclePic,
                        IsProperForRent = orderedCar.IsProperForRent,
                        VehicleNumber = orderedCar.VehicleNumber,
                        BranchesID = orderedCar.BranchesID
                    });
                }
                return carsInventory;
            }

        }

        public static int GetCarsTypeID(int vehiclesID)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                VehicleInventory getCarTypeId = ef.VehicleInventories.FirstOrDefault(u => u.VehiclesID == vehiclesID);
                return getCarTypeId.CarsTypeID;
            }
        }

        public static List<BOLCarInventory> GetCarFromForManager_db()
        {
            try
            {
                List<BOLCarInventory> carsInventory = new List<BOLCarInventory>();

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    foreach (var item in ef.VehicleInventories.ToList())
                    {
                        if (item.IsProperForRent)
                        {
                            carsInventory.Add(new BOLCarInventory
                            {
                                CarsTypeID = item.CarsTypeID,
                                UpdatedMileage = item.UpdatedMileage,
                                VehiclePic = item.VehiclePic,
                                IsProperForRent = item.IsProperForRent,
                                VehicleNumber = item.VehicleNumber,
                                BranchesID = item.BranchesID
                            });
                        }
                    }
                    return carsInventory;
                }

            }
            catch { }
            return null;
        }

        public static BOLCarInventory AddCarTo_db(BOLCarInventory car)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    VehicleInventory isExist = ef.VehicleInventories.FirstOrDefault(u => u.VehicleNumber == car.VehicleNumber);
                    if (isExist == null)
                    {
                        ef.VehicleInventories.Add(new VehicleInventory
                        {
                            CarsTypeID = car.CarsTypeID,
                            UpdatedMileage = car.UpdatedMileage,
                            VehiclePic = car.VehiclePic,
                            IsProperForRent = car.IsProperForRent,
                            VehicleNumber = car.VehicleNumber,
                            BranchesID = car.BranchesID
                        });
                        ef.SaveChanges();
                        return car;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car number is already exist please change and try again");

                    }
                }
            }
            catch 
            {
                return null;
            }
        }




        public static BOLCarInventory UpDataTo_db(BOLCarInventory oldCar, BOLCarInventory newCar)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    VehicleInventory dbUser = ef.VehicleInventories.FirstOrDefault(u => u.VehicleNumber == oldCar.VehicleNumber);
                    if (dbUser != null)
                    {
                        dbUser.CarsTypeID = newCar.CarsTypeID;
                        dbUser.UpdatedMileage = newCar.UpdatedMileage;
                        dbUser.VehiclePic = newCar.VehiclePic;
                        dbUser.IsProperForRent = newCar.IsProperForRent;
                        dbUser.VehicleNumber = newCar.VehicleNumber;
                        dbUser.BranchesID = newCar.BranchesID;

                        ef.SaveChanges();
                        return newCar;
                    }

                    else
                    {
                        throw new InvalidOperationException($"this car type is not exist please change the values and try again");
                    }
                }
            }
            catch 
            {
                return null;
            }
        }


        public static string deleteFrom_db(int VehicleNumber)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    VehicleInventory dbvehicle = ef.VehicleInventories.FirstOrDefault(u => u.VehicleNumber == VehicleNumber);
                   List< Order> isItInOrder = ef.Orders.Where(u => u.VehiclesID == dbvehicle.VehiclesID && u.ActualReturnDate != null).ToList();
                    if (isItInOrder.Count == 0)
                    {
                        if (dbvehicle != null)
                        {
                            ef.VehicleInventories.Remove(dbvehicle);
                            ef.SaveChanges();
                            return "deleted";
                        }
                        else
                        {
                            throw new InvalidOperationException($"this car type is not exist please change the values and try again");

                        }
                    }
                    else
                    {
                        return "this vehicle is in order";
                    }
                }
            }
            catch 
            {
                return "wrong vehicle number";
            }
        }



        public static int GetVehicleid(int vehicleNumber)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    VehicleInventory dbUser = ef.VehicleInventories.FirstOrDefault(u => u.VehicleNumber == vehicleNumber);

                    if (dbUser != null)
                    {
                        return dbUser.VehiclesID;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car is not exist please change  the values and try again");
                    }
                }
            }
            catch 
            {
                return 0;
            }

        }


        public static int GetVehicleNumber(int vehiclesID)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    VehicleInventory dbUser = ef.VehicleInventories.FirstOrDefault(u => u.VehiclesID == vehiclesID);

                    if (dbUser != null)
                    {
                        return dbUser.VehicleNumber;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this car is not exist please change  the values and try again");
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

