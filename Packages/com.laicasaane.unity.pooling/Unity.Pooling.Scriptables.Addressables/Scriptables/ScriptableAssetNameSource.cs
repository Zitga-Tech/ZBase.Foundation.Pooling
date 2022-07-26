using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public abstract class ScriptableAssetNameSource : ScriptableSource
    {
        [SerializeField]
        private string _assetName;

        protected string AssetName
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _assetName;
        }
    }
}
