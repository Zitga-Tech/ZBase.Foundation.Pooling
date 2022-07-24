using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class PrefabExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNull<T, TSource>(this IPrefab<T, TSource> prefab)
            where T : class
            => prefab != null && prefab.Source != null;
    }
}
