namespace FsaStore.Core.Enum
{
    using System;

    /// <summary>
    /// ProductType
    /// </summary>
    [Flags]
    public enum ProductNature
    {
        /// <summary>
        /// Any product of physical nature (e.g. Shoes)
        /// </summary>
        Physical = 1,

        /// <summary>
        /// Gift
        /// </summary>
        GiftWrapper = 2,

        /// <summary>
        /// Gift
        /// </summary>
        FreeGift = 3,

        /// <summary>
        /// Warranty
        /// </summary>
        Warranty = 4,

        /// <summary>
        /// Product is service
        /// </summary>
        Service = 5,

        /// <summary>
        /// Promotion Code
        /// </summary>
        Promotion = 6,

        /// <summary>
        /// Discount Code
        /// </summary>
        Discount = 7,

        /// <summary>
        /// Coupan Code
        /// </summary>
        Coupan = 8
    }
}