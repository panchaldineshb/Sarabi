using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class Division : EntityBase
    {
        //
        // Constructor
        public Division()
        {
            Departments = new HashSet<Department>();
        }

        //
        // User Locations
        public virtual ICollection<Department> Departments { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }
    }
}