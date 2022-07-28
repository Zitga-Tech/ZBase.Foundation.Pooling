namespace Unity.Pooling.AddressableAssets
{
    public class AddressableGameObjectPoolBehaviour
        : AssetNameGameObjectPoolBehaviour<
            AssetNameGameObjectPrefab<AddressableGameObjectInstantiator>
            , AddressableGameObjectInstantiator
            , AddressableGameObjectPool
        >
    {
    }
}