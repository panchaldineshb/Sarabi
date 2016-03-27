namespace TemplateApp.Data.Models
{
    public class Currency : EntityBase
    {
        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // Currency Sign
        public string Sign { get; set; }
    }
}