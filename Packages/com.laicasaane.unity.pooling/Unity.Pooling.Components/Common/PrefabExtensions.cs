
namespace Unity.Pooling.Components
{
    public static class PrefabExtensions
    {
        public static bool Validate<T>(this IUnityPrefab<T> prefab)
            where T : UnityEngine.Object
            => prefab != null && prefab.Prefab != false;

        public static bool Validate<TKey, T>(this IUnityPrefab<TKey, T> prefab)
            where T : UnityEngine.Object
            => prefab != null && prefab.Key != null && prefab.Prefab != false;
    }
}
