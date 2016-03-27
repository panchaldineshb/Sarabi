using System.Data.Entity;
using FsaStore.Core.Context;

using Ninject.Modules;

namespace FsaStore.Core.Modules
{
    public class DbContextModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<DomainContext>().InSingletonScope();
        }
    }
}