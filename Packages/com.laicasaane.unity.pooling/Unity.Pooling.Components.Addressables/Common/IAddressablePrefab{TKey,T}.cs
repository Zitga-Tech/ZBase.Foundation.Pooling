namespace Unity.Pooling.Components.AddressableAssets
{
    public interface IAddressablePrefab<TKey, T> : IPrefab<TKey, T>, IAddressablePrefab<T>
        where T : class
    {
    }
}
