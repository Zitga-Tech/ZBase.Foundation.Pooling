namespace Unity.Pooling.AddressableAssets
{
    public abstract class AssetNamePoolBehaviour<T, TInstantiator, TPrefab, TPool, TPrepooler>
        : UnityPoolBehaviour<T, string, TPrefab, TPool, TPrepooler>
        where T : UnityEngine.Object
        where TInstantiator : IAssetNameInstantiator<T>, new()
        where TPrefab : AssetNamePrefab<T, TInstantiator>
        where TPool : AssetNamePool<T, TInstantiator, TPrefab>
        where TPrepooler : AssetNamePrepooler<T, TInstantiator, TPrefab, TPool>, new()
    {
    }
}
