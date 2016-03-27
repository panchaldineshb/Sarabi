using System;

namespace FsaStore.Core.Models
{
    public abstract class EntityBase
    {
        //
        // Whether entity is Active?
        public int Active { get; set; }

        //
        // Entity's CreatedUtc
        public DateTime CreatedUtc { get; set; }

        //
        // Entity's DisplayName
        public string DisplayName { get; set; }

        //
        // Whether entity is Locked?
        // Locked entity is not allowed to change (needs special access permission)
        public int Locked { get; set; }

        //
        // Entity's Name
        public string Name { get; set; }

        //
        // Whether entity is Purged?
        // Purged entity can be moved to historical tables or archived
        public int Purged { get; set; }

        //
        // Entity's UpdatedUtc
        public DateTime UpdatedUtc { get; set; }

        //
        // Whether entity is Active?
        public int Visible { get; set; }
    }
}