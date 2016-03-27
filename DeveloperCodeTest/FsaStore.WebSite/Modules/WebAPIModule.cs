using FsaStore.WebAPI.Controllers;
using FsaStore.WebAPI.Mappers;
using Ninject.Modules;

namespace FsaStore.WebSite.Modules
{
    public class WebAPIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ShoppingController>().ToSelf();
            Bind<AccountMapper>().ToSelf();
        }
    }
}