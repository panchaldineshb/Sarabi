namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Account
    /// </summary>
    public class Account : EntityBase, IEntity<Account>
    {
        //
        // Location
        public Location Location { get; set; }

        //
        // Company
        public Company Company { get; set; }

        //
        // Email
        public string Email { get; set; }

        //
        // Firstname
        public string Firstname { get; set; }

        //
        // Has
        public string Hash { get; set; }

        //
        // Lastname
        public string Lastname { get; set; }

        //
        // Password
        public string Password { get; set; }
        //
        // Phone
        public string Phone { get; set; }

        //
        // SecondPhone
        public string SecondPhone { get; set; }
    }
}