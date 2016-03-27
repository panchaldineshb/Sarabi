namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// PromotionCode
    /// </summary>
    public class PromotionCode : EntityBase, IEntity<PromotionCode>
    {
        //
        // Description
        public string Description { get; set; }

        //
        // Product belong to Company
        public SalesCampaign Campaign { get; set; }
    }
}