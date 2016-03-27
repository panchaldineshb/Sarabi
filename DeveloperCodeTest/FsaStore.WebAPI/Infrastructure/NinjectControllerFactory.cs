using System.Web.Mvc;

using Ninject;

namespace FsaStore.WebAPI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
        }
    }
}