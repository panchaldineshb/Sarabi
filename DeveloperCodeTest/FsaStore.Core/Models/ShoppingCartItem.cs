namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class ShoppingCartItem : EntityBase, IEntity<ShoppingCartItem>
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
        /// ShoppingCart
        /// </summary>
        public ShoppingCart ShoppingCart { get; set; }
    }
}