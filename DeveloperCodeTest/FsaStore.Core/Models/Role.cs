namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    public static class RoleExtension
    {
        public static bool IsAdministrator(this Role role)
        {
            return string.Compare(role.Name, "Administrator", false) == 0;
        }

        public static bool IsManager(this Role role)
        {
            return string.Compare(role.Name, "Manager", false) == 0;
        }

        public static bool IsTester(this Role role)
        {
            return string.Compare(role.Name, "Tester", false) == 0;
        }

        public static bool IsABTesting(this Role role)
        {
            return string.Compare(role.Name, "A/B Testing", false) == 0;
        }

        public static bool IsUser(this Role role)
        {
            return string.Compare(role.Name, "User", false) == 0;
        }
    }

    /// <summary>
    /// Role and Profile are used exchangibly over here
    /// </summary>
    public class Role : EntityBase, IEntity<Role>
    {
    }
}