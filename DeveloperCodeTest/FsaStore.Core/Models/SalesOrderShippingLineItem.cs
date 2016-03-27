namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class SalesOrderShippingLineItem : EntityBase, IEntity<SalesOrderShippingLineItem>
    {
        //
        // SalesOrderLineItem
        public SalesOrderLineItem Item { get; set; }

        /// <summary>
        /// SalesOrderShipping
        /// It will force you to create sales-order and then add it to line item
        /// We are referencing Parernt from Child instead of having child collection inside parent
        /// </summary>
        public SalesOrderShipping Shipping { get; set; }

    }
}