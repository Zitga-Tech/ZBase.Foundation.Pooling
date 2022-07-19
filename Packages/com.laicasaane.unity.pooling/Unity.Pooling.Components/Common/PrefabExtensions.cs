namespace Unity.Pooling.Components
{
    public static class PrefabExtensions
    {
        public static bool Validate<T>(this IPrefab<T> prefab)
            where T : class
            => prefab != null && prefab.Source != null;

        public static bool Validate<TKey, T>(this IPrefab<TKey, T> prefab)
            where T : class
            => prefab != null && prefab.Key != null && prefab.Source != null;
    }
}
