using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class Role : EntityBase
    {
        //
        // Constructor
        public Role()
        {
            Permissions = new HashSet<Permission>();
        }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // Whether entity is Active?
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}