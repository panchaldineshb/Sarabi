namespace TemplateApp.Data.Models
{
    public class Location : EntityBase
    {
        //
        // Address
        public string Address { get; set; }

        //
        // City
        public string City { get; set; }

        //
        // Entity's CountryCode
        public string CountryCode { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // StateCode
        public string StateCode { get; set; }

        //
        // ZipCode
        public string ZipCode { get; set; }
    }
}