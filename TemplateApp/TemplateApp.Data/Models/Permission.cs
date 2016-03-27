namespace TemplateApp.Data.Models
{
    public class Permission : EntityBase
    {
        //
        // Whether permission Granted?
        public int Granted { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }
    }
}