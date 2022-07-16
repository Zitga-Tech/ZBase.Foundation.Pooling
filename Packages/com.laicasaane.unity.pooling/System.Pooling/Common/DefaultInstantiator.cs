using System;

namespace System.Pooling
{
    internal static class DefaultInstantiator<T>
    {
        private static readonly Type s_type = typeof(T);

        public static T Instantiate() => (T)Activator.CreateInstance(s_type);
    }
}
