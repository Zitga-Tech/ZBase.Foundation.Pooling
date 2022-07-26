using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public static class DefaultInstantiator<T> where T : class
    {
        private static readonly Type s_type = typeof(T);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T Instantiate() => (T)Activator.CreateInstance(s_type);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T> Get()
            => Instantiate;
    }
}
