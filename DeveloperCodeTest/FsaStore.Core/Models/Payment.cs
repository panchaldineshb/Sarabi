namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Product
    /// </summary>
    public class CashPayment : EntityBase, IEntity<CashPayment>
    {
        /// <summary>
        /// AccountProfile
        /// </summary>
        public SalesOrderPayment SalesOrderPayment { get; set; }
    }

    /// <summary>
    /// Product
    /// </summary>
    public class CheckPayment : EntityBase, IEntity<CheckPayment>
    {
        /// <summary>
        /// SalesOrderPayment
        /// </summary>
        public SalesOrderPayment SalesOrderPayment { get; set; }
    }

    /// <summary>
    /// Product
    /// </summary>
    public class CreditCardPayment : EntityBase, IEntity<CreditCardPayment>
    {
        /// <summary>
        /// AccountProfile
        /// </summary>
        public SalesOrderPayment SalesOrderPayment { get; set; }
    }

    /// <summary>
    /// PayPalPayment
    /// </summary>
    public class PayPalPayment : EntityBase, IEntity<PayPalPayment>
    {
        /// <summary>
        /// AccountProfile
        /// </summary>
        public SalesOrderPayment SalesOrderPayment { get; set; }
    }
}