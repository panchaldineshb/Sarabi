namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Company
    /// </summary>
    public class Company : EntityBase, IEntity<Company>
    {
        public virtual string Email { get; set; }
    }
}