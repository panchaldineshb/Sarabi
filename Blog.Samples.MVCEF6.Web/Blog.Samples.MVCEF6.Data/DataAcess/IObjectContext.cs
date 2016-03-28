using System;
using System.Data.Entity.Core.Objects;

namespace Blog.Samples.MVCEF6.Data.DataAcess
{
    public interface IObjectContext : IDisposable
    {
        void SaveChanges();
        ObjectContextOptions ContextOptions { get; }
    }
}
