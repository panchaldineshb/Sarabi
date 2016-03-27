namespace FsaStore.Core.Abstracts
{
    using System;

    public interface IEntity<TEntity>
        where TEntity : class
    {
        //
        // Identification (ExternalId)
        Guid ExternalId { get; set; }

        //
        // Identification (Primary Key)
        int Id { get; set; }
    }
}