namespace FsaStore.DeveloperCodeTest.Code
{
    using System;

    /// <summary>
    /// an enumeration of available products
    /// </summary>
    [Flags]
    public enum Product
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