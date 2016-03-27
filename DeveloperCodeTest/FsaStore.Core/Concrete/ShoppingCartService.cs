namespace FsaStore.Core.Concrete
{
    using System.Collections.Generic;

    using FsaStore.Core.Abstracts;

    using FsaStore.Core.Models;

    /// <summary>
    /// The pricing service is responsible for calculating the price of a product for a given user.
    /// </summary>
    public class ShoppingCartService : IShoppingCartService
    {
        /// <summary>
        /// Gets the set of products in the shopping cart
        /// </summary>
        public IEnumerable<Product> Products { get; private set; }

        /// <summary>
        /// Adds the quantity of the product to the shopping cart
        /// </summary>
        /// <param name="product">the product to be added</param>
        /// <param name="quantity">the quantity to add</param>
        public void Add(Product product, int quantity = 1)
        {
        }

        /// <summary>
        /// Counts the quantity of the product in the shopping cart
        /// </summary>
        /// <param name="product">the product(s) to include in the count</param>
        /// <returns>The <see cref="int" />.</returns>
        public int CountItems(Product product)
        {
            return 0;
        }

        /// <summary>
        /// Gets the aggregate price of the items in the shopping cart
        /// </summary>
        /// <param name="pricingService">The pricing Service.</param>
        /// <returns>The <see cref="decimal" />.</returns>
        public decimal GetTotalPrice(IPricingService pricingService)
        {
            return 0.0m;
        }

        /// <summary>
        /// Removes the quantity of the product from the shopping cart
        /// </summary>
        /// <param name="product">the product to be removed</param>
        /// <param name="quantity">the quantity to remove</param>
        public void Remove(Product product, int quantity = 1)
        {
        }
    }
}