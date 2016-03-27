namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class SalesOrderLineItem : EntityBase, IEntity<SalesOrderLineItem>
    {
        //
        // Discount
        public decimal Discount { get; set; }

        /// <summary>
        /// Products
        /// </summary>
        public Product Product { get; set; }

        //
        // PromotionCode
        public PromotionCode PromotionCode { get; set; }

        //
        // SalePrice
        public decimal SalePrice { get; set; }

        /// <summary>
        /// SalesOrder
        /// It will force you to create sales-order and then add it to line item
        /// We are referencing Parernt from Child instead of having child collection inside parent
        /// </summary>
        public SalesOrder SalesOrder { get; set; }
    }
}