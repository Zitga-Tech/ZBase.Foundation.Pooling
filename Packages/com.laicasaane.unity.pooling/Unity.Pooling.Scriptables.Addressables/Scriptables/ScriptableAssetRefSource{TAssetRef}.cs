using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public abstract class ScriptableAssetRefSource<TAssetRef> : ScriptableSource
        where TAssetRef : AssetReference
    {
        [SerializeField]
        private TAssetRef _source;

        protected TAssetRef Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;
        }
    }
}
