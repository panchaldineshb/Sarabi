using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class PriceGroup : EntityBase
    {
        //
        // Constructor
        public PriceGroup()
        {
            PriceLevels = new HashSet<PriceLevel>();
        }

        //
        // Company
        public Company Company { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // Products
        public virtual ICollection<PriceLevel> PriceLevels { get; set; }

        //
        // Product
        public Product Product { get; set; }

        //
        // ProductCategory
        public ProductCategory ProductCategory { get; set; }
        //
        // Subsidiary
        public Subsidiary Subsidiary { get; set; }
    }
}