namespace Unity.Pooling.Components.AddressableAssets
{
    public interface IAddressablePrefab<T> : IPrefab<T>, IAddressablePrefab
        where T : class
    {
    }
}
