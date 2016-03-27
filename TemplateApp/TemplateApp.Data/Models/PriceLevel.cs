namespace TemplateApp.Data.Models
{
    public class PriceLevel : EntityBase
    {
        //
        // Company
        public Company Company { get; set; }

        //
        // Whether entity is Active?
        public string Description { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

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