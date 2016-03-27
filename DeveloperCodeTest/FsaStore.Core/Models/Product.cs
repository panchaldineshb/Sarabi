namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;
    using FsaStore.Core.Enum;

    /// <summary>
    /// Product
    /// </summary>
    public class Product : EntityBase, IEntity<Product>
    {
        //
        // Price
        public Price Price { get; set; }

        //
        // Description
        public string Description { get; set; }

        //
        // Product Group
        public ProductGroup ProductGroup { get; set; }

        //
        // Product Nature
        public ProductNature ProductNature { get; set; }

        //
        // Product Type
        public ProductType ProductType { get; set; }
    }
}