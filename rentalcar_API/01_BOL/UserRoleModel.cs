namespace _01_BOL
{
    public class UserRoleModel
    {
        public string UserName { get; set; }
        public int UserRole { get; set; }

        public string GetUserRole()
        {
            switch (UserRole)
            {
                case 1: return "manager";
                case 2: return "worker";
                default: return "client";
            }
        }
    }
}
