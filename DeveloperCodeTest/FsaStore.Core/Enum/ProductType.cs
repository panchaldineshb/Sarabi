namespace FsaStore.Core.Enum
{
    using System;

    /// <summary>
    /// ProductType
    /// </summary>
    [Flags]
    public enum ProductType
    {
        /// <summary>
        /// any product
        /// </summary>
        Any = 0,

        /// <summary>
        /// a thermometer
        /// </summary>
        Thermometer = 1 << 0,

        /// <summary>
        /// a first aid kit
        /// </summary>
        FirstAidKit = 1 << 1,

        /// <summary>
        /// a bottle of Advil
        /// </summary>
        Advil = 1 << 2
    }
}