namespace FsaStore.Core.Concrete
{
    using FsaStore.Core.Abstracts;

    using FsaStore.Core.Models;

    /// <summary>
    /// The pricing service is responsible for calculating the price of a product for a given user.
    /// </summary>
    public class PricingService : IPricingService
    {
        /// <summary>
        /// Calculates the price of the product for the user
        /// </summary>
        /// <param name="product">the product</param>
        /// <param name="user">the user</param>
        /// <returns>The <see cref="decimal" /> price of the product for the user.</returns>
        public decimal CalculatePrice(Product product, Account profile)
        {
            return 0.0m;
        }
    }
}