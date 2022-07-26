namespace Unity.Pooling.AddressableAssets
{
    public class AddressableComponentPool<T>
        : AssetNameComponentPool<T, AddressableComponentInstantiator<T>, AddressableComponentPrefab<T>>
        where T : UnityEngine.Component
    {
    }
}
