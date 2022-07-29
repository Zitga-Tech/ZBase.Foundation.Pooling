using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public abstract class ScriptableAssetRefSource<TAssetRef> : ScriptableSource<TAssetRef>
        where TAssetRef : AssetReference
    {
    }
}
