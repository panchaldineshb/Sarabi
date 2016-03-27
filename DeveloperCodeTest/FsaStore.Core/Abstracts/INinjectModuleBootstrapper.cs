using System.Collections.Generic;

using Ninject.Modules;

namespace FsaStore.Core.Abstracts
{
    public interface INinjectModuleBootstrapper
    {
        IList<INinjectModule> GetModules();
    }
}