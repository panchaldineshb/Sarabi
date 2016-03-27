namespace FsaStore.Core.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FsaStore.Core.Models;

    /// <summary>
    /// The model for user Registration
    /// </summary>
    public class RegistrationViewModel
    {
        //
        // Apt
        [Display(Name = "Apt")]
        public string Apt { get; set; }

        //
        // City
        [Display(Name = "City")]
        public string City { get; set; }

        //
        // Address
        [Display(Name = "Companies")]
        public ICollection<Company> Companies { get; set; }

        //
        // Company
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        //
        // Country
        [Display(Name = "Country")]
        public string Country { get; set; }

        //
        // County
        [Display(Name = "County")]
        public string County { get; set; }

        //
        // Email
        [Display(Name = "Email")]
        public string Email { get; set; }

        //
        // Firstname
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        //
        // Lastname
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        //
        // Password
        [Display(Name = "Password")]
        public string Password { get; set; }

        //
        // Phone
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        //
        // SecondPhone
        [Display(Name = "Second Phone")]
        public string SecondPhone { get; set; }

        //
        // State
        [Display(Name = "State")]
        public string State { get; set; }

        //
        // Street
        [Display(Name = "Street")]
        public string Street { get; set; }
        //
        // Zip
        [Display(Name = "Zip")]
        public string Zip { get; set; }
    }
}