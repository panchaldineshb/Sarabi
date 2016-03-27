namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Account
    /// </summary>
    public class SystemSetting : EntityBase, IEntity<SystemSetting>
    {
        //
        // Company
        public Company Company { get; set; }

        //
        // Has
        public string Hash { get; set; }

        //
        // Email
        public string Key { get; set; }

        //
        // Password
        public string Value { get; set; }
    }
}