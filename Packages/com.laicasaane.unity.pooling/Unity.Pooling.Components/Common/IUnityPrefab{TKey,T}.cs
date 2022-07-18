namespace Unity.Pooling.Components
{
    public interface IUnityPrefab<TKey, T> : IUnityPrefab
        where T : UnityEngine.Object
    {
        TKey Key { get; set; }

        T Prefab { get; set; }
    }
}
