using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class ProductCategory : EntityBase
    {
        //
        // Constructor
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        //
        // Company
        public Company Company { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // Products
        public virtual ICollection<Product> Products { get; set; }

        //
        // Subsidiary
        public Subsidiary Subsidiary { get; set; }
    }
}