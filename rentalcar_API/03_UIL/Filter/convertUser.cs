using _01_BOL;
using _03_UIL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_UIL.Filter
{
    public class convertUser
    {
        public static List<UserModel> convertFromBOLtoModel(List<BOLUserInfo> userInfo)
        {
            List<UserModel> usermodel = new List<UserModel>();
            try
            {
                foreach (var item in userInfo)
                {
                    usermodel.Add(new UserModel
                    {

                        FullUserName = item.FullUserName,
                        UserIdNumber = item.UserIdNumber,
                        UserName = item.UserName,
                        Password = item.Password,
                        BirthDay = item.BirthDay,
                        Sex = item.Sex ? "male" : "female",
                        UserRole = getRole(item.UserRole),
                        UserPic = item.UserPic,
                        Email = item.Email,
                    });
                }

                return usermodel;
            }
            catch
            {

                return null;
            }
        }

        private static string getRole(int userRole)
        {
            switch (userRole)
            {
                case 1: return "admin";
                case 2: return "worker";
                default: return "castomer";
            }
        }
        private static int getRole(string userRole)
        {
            switch (userRole)
            {
                case "admin": return 1;
                case "worker": return 2;
                default: return 0;
            }
        }

        public static UserModel convertUserFromBOLtoModel(BOLUserInfo userInfo)
        {
            try
            {
                UserModel usermodel=     new UserModel
                    {

                        FullUserName = userInfo.FullUserName,
                        UserIdNumber = userInfo.UserIdNumber,
                        UserName = userInfo.UserName,
                        Password = userInfo.Password,
                        BirthDay = userInfo.BirthDay,
                        Sex = userInfo.Sex ? "male" : "female",
                        UserRole = getRole(userInfo.UserRole),
                        UserPic = userInfo.UserPic,
                        Email = userInfo.Email,
                    };
                return usermodel;
            }
            catch
            {

                return null;
            }
        }

        internal static BOLUserInfo convertUserFromModeltoBOL(UserModel value)
        {
            try
            {
                BOLUserInfo usermodel = new BOLUserInfo
                {

                    FullUserName = value.FullUserName,
                    UserIdNumber = value.UserIdNumber,
                    UserName = value.UserName,
                    Password = value.Password,
                    BirthDay = value.BirthDay,
                    Sex = value.Sex== "male" ? true : false,
                    UserRole = getRole(value.UserRole),
                    UserPic = value.UserPic,
                    Email = value.Email,
                };
                return usermodel;
            }
            catch
            {

                return null;
            }
        }
    }
}