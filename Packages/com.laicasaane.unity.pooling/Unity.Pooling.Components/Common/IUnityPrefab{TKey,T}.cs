namespace Unity.Pooling.Components
{
    public interface IUnityPrefab<TKey, T> : IUnityPrefab<T>
        where T : UnityEngine.Object
    {
        TKey Key { get; set; }
    }
}
