using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class Subsidiary : EntityBase
    {
        //
        // Constructor
        public Subsidiary()
        {
            Locations = new HashSet<Location>();
            Subsidiaries = new HashSet<Subsidiary>();
            Divisions = new HashSet<Division>();
        }

        //
        // Currency
        public Currency Currency { get; set; }

        //
        // Divisions
        public virtual ICollection<Division> Divisions { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // Locations
        public virtual ICollection<Location> Locations { get; set; }

        //
        // Subsidiaries
        public virtual ICollection<Subsidiary> Subsidiaries { get; set; }
    }
}