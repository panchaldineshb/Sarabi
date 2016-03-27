namespace FsaStore.Core.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FsaStore.Core.Models;

    /// <summary>
    /// The model for user Dashboard
    /// </summary>
    public class DashboardViewModel
    {
        //
        // Address
        [Display(Name = "Address")]
        public string Address { get; set; }

        //
        // Address
        [Display(Name = "Companies")]
        public ICollection<Company> Companies { get; set; }

        //
        // Company
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

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
    }
}