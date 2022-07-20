using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components
{
    [Serializable]
    public abstract class AssetLoader<TRef, T> : IAssetLoader<TRef, T>
        where T : class
    {
        [SerializeField]
        private TRef _reference;

        public TRef Reference
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _reference;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _reference = value;
        }

        public abstract UniTask<T> Load();
    }
}
