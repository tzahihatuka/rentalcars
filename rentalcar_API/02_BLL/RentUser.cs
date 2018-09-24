using _01_BOL;
using _00_DAL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_BLL
{
    public class RentUser
    {

        public static BOLUserInfo GetLoginUserFrom_db(string UserIdNumber)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    BOLUserInfo UsersInfo = new BOLUserInfo();

                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == UserIdNumber);
                    if (dbUser != null)
                    {
                        UsersInfo.FullUserName = dbUser.FullUserName;
                        UsersInfo.UserIdNumber = dbUser.UserIdNumber;
                        UsersInfo.UserName = dbUser.UserName;
                        UsersInfo.Password = dbUser.Password;
                        UsersInfo.BirthDay = dbUser.BirthDay;
                        UsersInfo.Sex = dbUser.Sex;
                        UsersInfo.UserRole = dbUser.UserRole;
                        UsersInfo.UserPic = dbUser.UserPic;
                        UsersInfo.Email = dbUser.Email;

                        return UsersInfo;
                    }
                }
            }
            catch { return null; }
            return null;

        }

        public static List<BOLUserInfo> GetAllUsers()
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    List<BOLUserInfo> ListUsersInfo = new List<BOLUserInfo>();

                    List<UserTable> dbUser = ef.UserTables.Select(u => u).ToList();
                    foreach (var item in dbUser)
                    {
                        ListUsersInfo.Add(new BOLUserInfo
                        {

                            FullUserName = item.FullUserName,
                            UserIdNumber = item.UserIdNumber,
                            UserName = item.UserName,
                            Password = item.Password,
                            BirthDay = item.BirthDay,
                            Sex = item.Sex,
                            UserRole = item.UserRole,
                            UserPic = item.UserPic,
                            Email = item.Email,
                        });
                    }

                    return ListUsersInfo;
                }
            }
            catch
            { return null; }

        }

        public static string GetUserName(int userID)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                BOLUserInfo UsersInfo = new BOLUserInfo();

                UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserID == userID);
                if (dbUser != null)
                {
                    return dbUser.UserName;
                }
                else
                {
                    return null;
                }
            }
        }

        public static int GetLogin(string userName, string password)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                UserTable user = ef.UserTables.FirstOrDefault(u => u.UserName == userName && u.Password == password);
                int UserRole = user.UserRole;
                return UserRole;
            }

        }

        public static string AddUserTo_db(BOLUserInfo userInfo)
        {
            try
            {

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {


                    ValidateUserInput.CheckUnique(userInfo.UserName, userInfo.UserIdNumber);

                    ef.UserTables.Add(new UserTable
                    {
                        FullUserName = userInfo.FullUserName,
                        UserIdNumber = userInfo.UserIdNumber,
                        UserName = userInfo.UserName,
                        Password = userInfo.Password,
                        BirthDay = userInfo.BirthDay,
                        Sex = userInfo.Sex,
                        UserRole = 0,
                        UserPic = userInfo.UserPic,
                        Email = userInfo.Email
                    });
                    ef.SaveChanges();
                    return "OK";
                }
            }
            catch
            {
                return "Something is wrong with the data";
            }
        }



        public static string UpDataTo_db(BOLUserInfo olduserInfo, BOLUserInfo newuserInfo)
        {
            try
            {
                if (newuserInfo.UserRole != 0)
                {
                    ValidateUserInput.CheckRole(newuserInfo.UserRole);
                }

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == olduserInfo.UserIdNumber);

                    dbUser.FullUserName = newuserInfo.FullUserName;
                    dbUser.UserIdNumber = newuserInfo.UserIdNumber;
                    dbUser.UserName = newuserInfo.UserName;
                    dbUser.Password = newuserInfo.Password;
                    dbUser.BirthDay = newuserInfo.BirthDay;
                    dbUser.Sex = newuserInfo.Sex;
                    dbUser.UserRole = newuserInfo.UserRole;
                    dbUser.UserPic = newuserInfo.UserPic;
                    dbUser.Email = newuserInfo.Email;

                    ef.SaveChanges();
                    return "OK";

                }
            }
            catch
            {
                return "Something is wrong with the data";
            }
        }


        public static string deleteFrom_db(string id)
        {
            try
            {
                ValidateUserInput.IsThisUserexists(id);

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == id);
                    List<Order> ishaveOrder = ef.Orders.Where(u => u.UserID == dbUser.UserID && u.ActualReturnDate != null).ToList();
                    if (ishaveOrder.Count == 0)
                    {
                        ef.UserTables.Remove(ef.UserTables.FirstOrDefault(u => u.UserIdNumber == id));
                        ef.SaveChanges();
                        return "OK";
                    }
                    else
                    {
                        return "This user has an order in his name";
                    }

                }
            }
            catch
            {
                return "Something is wrong with the data";
            }
        }

        public static int GetUserid(string userName)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserName == userName);

                    if (dbUser != null)
                    {
                        return dbUser.UserID;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this user is not exist please change  the values and try again");
                    }
                }
            }
            catch
            {
                return 0;
            }
        }


        public static string GetUserIdNumber(string UserName)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserName == UserName);

                    if (dbUser != null)
                    {
                        return dbUser.UserIdNumber;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this user is not exist please change  the values and try again");
                    }
                }
            }
            catch (Exception EX)
            {
                return EX.ToString();
            }
        }
        public static string GetUserNume(string userid)
        {
            try
            {
                BOLUserInfo a = new BOLUserInfo();
                a.UserIdNumber = userid;
                userid = a.UserIdNumber;

                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == userid);

                    if (dbUser != null)
                    {
                        return dbUser.UserName;
                    }
                    else
                    {
                        throw new InvalidOperationException($"this user is not exist please change  the values and try again");
                    }
                }
            }
            catch (Exception EX)
            {
                return EX.ToString();
            }
        }
    }

}


