namespace TemplateApp.Data.Models
{
    public class Department : EntityBase
    {
        //
        // Entity's CostCenter
        public CostCenter CostCenter { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }
    }
}