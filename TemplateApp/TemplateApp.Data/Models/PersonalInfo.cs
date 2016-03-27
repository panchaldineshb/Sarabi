using System;
using System.Collections.Generic;

namespace TemplateApp.Data.Models
{
    public class PersonalInfo : EntityBase
    {
        //
        // Constructor
        public PersonalInfo()
        {
            SecurityInfo = new HashSet<SecurityInfo>();
        }

        //
        // Entity's DateOfBirth
        public DateTime? DateOfBirth { get; set; }

        //
        // Entity's FirstName
        public string FirstName { get; set; }

        //
        // Identification (Primary Key)
        public int Id { get; set; }

        //
        // Entity's LastName
        public string LastName { get; set; }

        //
        // Entity's MaidenName
        public string MaidenName { get; set; }

        //
        // Entity's MiddleName
        public string MiddleName { get; set; }

        //
        // Entity's Password
        public string Password { get; set; }

        //
        // Entity's PasswordHash
        public string PasswordHash { get; set; }

        //
        // Security Question and Answers
        public virtual ICollection<SecurityInfo> SecurityInfo { get; set; }
    }
}