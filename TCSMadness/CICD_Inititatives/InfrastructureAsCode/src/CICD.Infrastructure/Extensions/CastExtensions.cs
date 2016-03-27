using System;
using System.Reflection;

namespace CICD.Infrastructure.Extensions
{
    public static class CastExtensions
    {
        public static bool IsInstanceOftype(this Type type, object obj)
        {
            return obj != null && type.GetTypeInfo().IsAssignableFrom(obj.GetType().GetTypeInfo());
        }

        public static T As<T>(this object @object) where T : class
        {
            return @object as T;
        }

        public static T CastAs<T>(this object @object)
        {
            return (T)@object;
        }
    }
}