namespace FsaStore.Core.Models
{
    using System.Collections.Generic;

    using FsaStore.Core.Abstracts;

    /// <summary>
    /// PromotionCode
    /// </summary>
    public class SalesCampaignExclusion : EntityBase, IEntity<SalesCampaignExclusion>
    {
        //
        // Description
        public string Description { get; set; }

        //
        // Compaign Exclusion list of ProductGroup
        public ICollection<ProductGroup> ExcludedProductGroups { get; set; }

        //
        // Compaign Exclusion list of ProductGroup
        public ICollection<Product> ExcludedProducts { get; set; }

        //
        // Product belong to Company
        public SalesCampaign SalesCampaign { get; set; }
    }
}