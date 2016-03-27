namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Account
    /// </summary>
    public class Customer : EntityBase, IEntity<Customer>
    {
        //
        // Account
        public Account Account { get; set; }
    }
}