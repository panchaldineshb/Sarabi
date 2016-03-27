namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Account
    /// </summary>
    public class AccountProfile : EntityBase, IEntity<AccountProfile>
    {
        //
        // Account
        public Account Account { get; set; }

        //
        // Account Role (Difference between Account Role and Profile)
        public Role Role { get; set; }
    }
}