namespace FsaStore.DeveloperCodeTest.Code
{
    using System;
    using System.Linq;
    using System.Security.Principal;

    /// <summary>
    /// Extension methods for accessing the customer's test profile from the user roles.
    /// </summary>
    public static class CustomerTestProfileExtensions
    {
        /// <summary>
        /// Retrieves the identifier for the user's customer A/B testing profile
        /// </summary>
        /// <param name="user">the user (required)</param>
        /// <exception>
        /// <cref>T:ArgumentNullException</cref> when the <paramref name="user" /> is null
        /// </exception>
        /// <returns>
        /// The <see cref="CustomerTestProfile" /> associated with the user or <example>A</example>
        /// if none has been assigned.
        /// </returns>
        public static CustomerTestProfile TestProfile(this IPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return
                Enum.GetValues(typeof(CustomerTestProfile))
                    .Cast<CustomerTestProfile>()
                    .SingleOrDefault(profile => user.IsInRole(profile.ToString()));
        }
    }
}