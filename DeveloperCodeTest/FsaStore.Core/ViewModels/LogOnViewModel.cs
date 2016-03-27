namespace FsaStore.Core.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The model for user logon
    /// </summary>
    public class LogOnViewModel
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user shall be remembered.
        /// </summary>
        /// <value><c>true</c> if the user shall be remembered; otherwise, <c>false</c>.</value>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}