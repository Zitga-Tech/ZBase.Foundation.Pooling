using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class PrefabExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Validate<T, TSource, TUnitySource>(this IPrefab<T, TSource, TUnitySource> prefab)
            where T : class
            where TUnitySource : ILoadableSource<TSource, T>
            => prefab != null && prefab.Source.Validate();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Validate<TKey, T, TSource, TUnitySource>(this IPrefab<TKey, T, TSource, TUnitySource> prefab)
            where T : class
            where TUnitySource : ILoadableSource<TSource, T>
            => prefab != null && prefab.Key != null && prefab.Source.Validate();
    }
}
