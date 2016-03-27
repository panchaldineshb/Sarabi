namespace TemplateApp.Data.Models
{
    public class SecurityInfo : EntityBase
    {
        //
        // City
        public string Answer { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // Address
        public string Question { get; set; }
    }
}