using System;

namespace TemplateApp.Data.Exceptions
{
    [Serializable]
    public class BootStrappingError : Exception
    {
        public BootStrappingError()
            : base("Bootstrapping error, you need to configure some dependencies yo.")
        {
        }
    }
}