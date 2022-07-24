using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class PrefabExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNull<T, TSource, TUnitySource>(this IPrefab<T, TSource, TUnitySource> prefab)
            where T : class
            where TUnitySource : IAsyncInstantiable<TSource, T>
            => prefab != null && prefab.Instantiator.IsNotNull();
    }
}
