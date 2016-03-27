namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Price
    /// </summary>
    public class Price : EntityBase, IEntity<Price>
    {
        //
        // BasePrice
        public decimal BasePrice { get; set; }

        //
        // Description
        public string Description { get; set; }

        //
        // Product Group
        public PriceGroup Group { get; set; }
    }
}