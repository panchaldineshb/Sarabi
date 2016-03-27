namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class SalesOrderPayment : EntityBase, IEntity<SalesOrder>
    {
        /// <summary>
        /// Customer
        /// </summary>
        public Customer Customer { get; set; }
    }
}