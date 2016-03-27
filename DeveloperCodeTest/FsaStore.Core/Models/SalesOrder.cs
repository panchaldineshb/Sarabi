namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class SalesOrder : EntityBase, IEntity<SalesOrder>
    {
        /// <summary>
        /// AccountProfile
        /// </summary>
        public Account Profile { get; set; }

        //
        // PromotionCode
        public PromotionCode PromotionCode { get; set; }
    }
}