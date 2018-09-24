using System;
using System.Collections.Generic;

namespace _01_BOL
{
    public class BOLUserInfo
    {
        public string FullUserName { get; set; }
        public string UserIdNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Sex { get; set; }
        public string UserPic { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }

        public List<BOLUserInfo> UserInfo { get; set; }
    }
}
