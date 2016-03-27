using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class User : EntityBase
    {
        //
        // Constructor
        public User()
        {
            Locations = new HashSet<Location>();
            Roles = new HashSet<Role>();
        }

        //
        // Users Company
        public Company Company { get; set; }

        //
        // Users Subsidiary
        public Subsidiary Subsidiary { get; set; }

        //
        // Users Department
        public Department Department { get; set; }

        //
        // Users Division
        public Division Division { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // User Locations
        public virtual ICollection<Location> Locations { get; set; }

        //
        // Entity's PersonalInfo
        public PersonalInfo PersonalInfo { get; set; }

        //
        // User Roles
        public virtual ICollection<Role> Roles { get; set; }
    }
}