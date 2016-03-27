namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class SalesOrderShipping : EntityBase, IEntity<SalesOrderShipping>
    {
        /// <summary>
        /// SalesOrder
        /// </summary>
        public SalesOrder SalesOrder { get; set; }
    }
}