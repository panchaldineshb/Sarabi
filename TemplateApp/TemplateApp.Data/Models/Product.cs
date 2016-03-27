namespace TemplateApp.Data.Models
{
    public class Product : EntityBase
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
        // Subsidiary
        public Subsidiary Subsidiary { get; set; }
    }
}