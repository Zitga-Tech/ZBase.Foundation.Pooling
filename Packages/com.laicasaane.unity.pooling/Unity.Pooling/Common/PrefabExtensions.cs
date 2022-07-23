using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class PrefabExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNull<T, TSource, TUnitySource>(this IPrefab<T, TSource, TUnitySource> prefab)
            where T : class
            where TUnitySource : IAsyncInstantiator<TSource, T>
            => prefab != null && prefab.Instantiator.IsNotNull();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNull<TKey, T, TSource, TUnitySource>(this IPrefab<TKey, T, TSource, TUnitySource> prefab)
            where T : class
            where TUnitySource : IAsyncInstantiator<TSource, T>
            => prefab != null && prefab.Key != null && prefab.Instantiator.IsNotNull();
    }
}
