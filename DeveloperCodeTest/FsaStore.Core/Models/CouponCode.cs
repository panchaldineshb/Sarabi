namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// PromotionCode
    /// </summary>
    public class CouponCode : EntityBase, IEntity<CouponCode>
    {
        //
        // Description
        public string Description { get; set; }

        //
        // Product belong to Company
        public SalesCampaign Campaign { get; set; }
    }
}