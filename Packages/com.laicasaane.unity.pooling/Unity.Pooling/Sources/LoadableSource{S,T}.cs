using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class LoadableSource<S, T> : ILoadableSource<S, T>
        where T : UnityEngine.Object
    {
        [SerializeField]
        private S _source;

        public LoadableSource() { }

        public LoadableSource(S source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public S Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _source = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract UniTask<T> Load();
    }
}
