using UnityEngine.AddressableAssets;
using ZBase.Foundation.Pooling.ScriptablePools;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public abstract class ScriptableAssetRefSource<TAssetRef> : ScriptableSource<TAssetRef>
        where TAssetRef : AssetReference
    {
    }
}
