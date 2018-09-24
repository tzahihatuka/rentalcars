
using _00_DAL;
using _01_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BLL
{
    public class RentBranches
    {
        public static List<BOLBranch> GetBranchFrom_db()
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<BOLBranch> carsBranch = new List<BOLBranch>();
                    foreach (var item in ef.Branches.ToList())
                    {
                        carsBranch.Add(new BOLBranch
                        {
                            Address = item.Address,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude,
                            BranchesName = item.BranchesName,

                        });
                    }
                    return carsBranch;
                }

            }
            catch { }
            return null;
        }


        public static void AddBranchTo_db(BOLBranch branch)
        {
            try {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    Branch dbUser = ef.Branches.FirstOrDefault(u => u.BranchesName == branch.BranchesName);
                    if (dbUser == null)
                    {
                        ef.Branches.Add(new Branch
                        {
                            Address = branch.Address,
                            Latitude = branch.Latitude,
                            Longitude = branch.Longitude,
                            BranchesName = branch.BranchesName
                        });
                        ef.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException($"this branch is exist please change the values and try again");
                    }
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }



        public static void UpDataTo_db(BOLBranch oldBranch, BOLBranch newBranch)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    Branch dbBranch = ef.Branches.FirstOrDefault(u => u.BranchesName == oldBranch.BranchesName);

                    if (dbBranch != null)
                    {
                        dbBranch.Address = newBranch.Address;
                        dbBranch.Latitude = newBranch.Latitude;
                        dbBranch.Longitude = newBranch.Longitude;
                        dbBranch.BranchesName = newBranch.BranchesName;

                        ef.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException($"this branch is not exist please change the values and try again");
                    }
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.ToString());
            }
        }

        public static void deleteFrom_db(BOLBranch BranchesName)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    Branch isExist = ef.Branches.FirstOrDefault(u => u.BranchesName == BranchesName.BranchesName);
                    if (isExist != null)
                    {
                        ef.Branches.Remove(isExist);
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


        public static int ReturnBrancheid(string branchesName)
        {

            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    Branch isExist = ef.Branches.FirstOrDefault(u => u.BranchesName == branchesName);
                    if (isExist != null)
                    {

                        return isExist.BranchesID;
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


        public static string ReturnBrancheName(int brancheid)
        {

            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    Branch isExist = ef.Branches.FirstOrDefault(u => u.BranchesID == brancheid);
                    if (isExist != null)
                    {

                        return isExist.BranchesName;
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
