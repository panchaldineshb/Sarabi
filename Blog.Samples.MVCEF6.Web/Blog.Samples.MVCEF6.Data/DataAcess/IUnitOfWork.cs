using System;

namespace Blog.Samples.MVCEF6.Data.DataAcess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        bool LazyLoadingEnabled { set; get; }
    }
}
