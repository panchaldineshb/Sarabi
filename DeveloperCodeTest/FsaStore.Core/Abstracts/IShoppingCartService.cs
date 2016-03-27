namespace FsaStore.Core.Abstracts
{
    using System.Collections.Generic;

    using FsaStore.Core.Models;

    /// <summary>
    /// A customer keeps intended purchases in a shopping cart until checkout
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Gets the set of products in the shopping cart
        /// </summary>
        IEnumerable<Product> Products { get; }

        /// <summary>
        /// Adds the quantity of the product to the shopping cart
        /// </summary>
        /// <param name="product">the product to be added</param>
        /// <param name="quantity">the quantity to add</param>
        void Add(Product product, int quantity = 1);

        /// <summary>
        /// Removes the quantity of the product from the shopping cart
        /// </summary>
        /// <param name="product">the product to be removed</param>
        /// <param name="quantity">the quantity to remove</param>
        void Remove(Product product, int quantity = 1);

        /// <summary>
        /// Counts the quantity of the product in the shopping cart
        /// </summary>
        /// <param name="product">the product(s) to include in the count</param>
        /// <returns>The <see cref="int" />.</returns>
        int CountItems(Product product);

        /// <summary>
        /// Gets the aggregate price of the items in the shopping cart
        /// </summary>
        /// <param name="pricingService">The pricing Service.</param>
        /// <returns>The <see cref="decimal" />.</returns>
        decimal GetTotalPrice(IPricingService pricingService);
    }
}