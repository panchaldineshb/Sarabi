using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class Customer : EntityBase
    {
        //
        // Constructor
        public Customer()
        {
            Locations = new HashSet<Location>();
        }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // User Locations
        public virtual ICollection<Location> Locations { get; set; }

        //
        // Entity's PersonalInfo
        public PersonalInfo PersonalInfo { get; set; }
    }
}