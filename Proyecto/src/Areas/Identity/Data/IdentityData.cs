using System;

namespace Proyecto.Areas.Identity.Data
{
    public static class IdentityData
    {
        public const string AdminUserName = "admin@contoso.com";

        public const string AdminName = "Administrator";

        public const string AdminMail = "admin@contoso.com";

        public static DateTime AdminDOB = new DateTime(1967, 3, 31);

        public const string AdminPassword = "P@55w0rd";

        public const string AdminRoleName = "Administrator";
        public const string Client ="Client";

        public static string[] NonAdminRoleNames = new string[] { "Cliente", "Técnico" };
    }
}