namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class PriceGroup : EntityBase, IEntity<PriceGroup>
    {
        //
        // Product belong to Company
        public Company Company { get; set; }

        //
        // Description
        public string Description { get; set; }
    }
}