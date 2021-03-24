using ClassAttendance.Domain;

namespace ClassAttendance.Common
{
    public static class Constants
    {
        public const string Version = "v0.1";

        public static class Roles
        {
            public static readonly ApplicationUserRole Admin = new ApplicationUserRole(1,"Admin");
            public static readonly ApplicationUserRole User = new ApplicationUserRole(2, "User");
            public static readonly ApplicationUserRole Transformer = new ApplicationUserRole(3, "Transformer");
        }
    }
}