namespace FsaStore.Core.Models
{
    using System;

    using System.Collections.Generic;

    using FsaStore.Core.Abstracts;

    /// <summary>
    /// PromotionCode
    /// </summary>
    public class SalesCampaign : EntityBase, IEntity<SalesCampaign>
    {
        //
        // Product belong to Company
        public Company Company { get; set; }

        //
        // Description
        public string Description { get; set; }

        //
        // Compaign End
        public DateTime End { get; set; }

        //
        // Compaign Start
        public DateTime Start { get; set; }
    }
}