namespace FsaStore.Core.Enum
{
    using System;

    /// <summary>
    /// EmailType
    /// </summary>
    [Flags]
    public enum EmailType
    {
        OrderConfirmation = 1,
        NewOrderCreated = 2,
    }
}