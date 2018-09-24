using _00_DAL;
using _01_BOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BLL
{
    public class ValidateUserInput
    {
        public static void CheckRole(int userRole)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                List<UserTable> getuserroll = ef.UserTables.Where(u => u.UserRole == userRole).ToList();
                Console.WriteLine(getuserroll);
                if (userRole == 1 && getuserroll.Count == 1)//worker
                {

                    throw new InvalidOperationException($"this role is already taken please change  {getuserroll[0].FullUserName} role and try again");
                }
                else if (getuserroll.Count == 5)
                {
                    throw new InvalidOperationException($"this role is already taken please change  {getuserroll[0].FullUserName}or {getuserroll[1].FullUserName} or{getuserroll[2].FullUserName} or{getuserroll[3].FullUserName}or {getuserroll[4].FullUserName} role and try again");
                }

            }
        }

        internal static void CheckUnique(string userName, string userIdNumber)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                UserTable getuseruserName = ef.UserTables.FirstOrDefault(u => u.UserName == userName);
                if (getuseruserName != null)//worker
                {
                    throw new InvalidOperationException($"this username is already taken");
                }

                UserTable getuseruserId = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == userIdNumber);
                if (getuseruserId != null)//worker
                {
                    throw new InvalidOperationException("you are already registered");
                }
            }
        }

        internal static void IsThisUserexists(string userIdNumber)
        {
            using (RentalcarsEntities1 ef = new RentalcarsEntities1())
            {
                UserTable getuseruserId = ef.UserTables.FirstOrDefault(u => u.UserIdNumber == userIdNumber);
                if (getuseruserId == null)//worker
                {
                    throw new InvalidOperationException("This User IS NOT exists");
                }
            }
        }

        public static BOLUserInfo GetUser(string name, string password)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    UserTable dbUser = ef.UserTables.FirstOrDefault(u => u.UserName == name && u.Password == password);
                    if (dbUser != null)
                    {
                        BOLUserInfo user = new BOLUserInfo
                        {
                            UserName = dbUser.UserName,
                            UserRole = dbUser.UserRole,
                        };
                        return user;
                    }

                }

            }
            catch (Exception) { }
            return null;
        }

    }
}