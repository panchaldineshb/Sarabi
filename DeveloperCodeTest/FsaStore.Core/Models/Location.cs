namespace FsaStore.Core.Models
{
    using FsaStore.Core.Abstracts;

    /// <summary>
    /// Company
    /// </summary>
    public class Location : EntityBase, IEntity<Location>
    {
        public virtual string Street { get; set; }
        public virtual string Apt { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual string County { get; set; }
        public virtual string Country { get; set; }
    }
}