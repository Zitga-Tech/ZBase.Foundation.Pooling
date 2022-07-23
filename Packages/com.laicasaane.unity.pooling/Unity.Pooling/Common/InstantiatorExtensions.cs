using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class InstantiatorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNull<TSource, T>(this IAsyncInstantiator<TSource, T> instantiator)
            where T : class
            => instantiator != null && instantiator.Source != null;
    }
}
