using System;
using System.Threading;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.ScriptablePools
{
    [Serializable]
    public class UnityObjectPrefab
        : IPrefab<UnityEngine.Object, ScriptableSource>
    {
        [SerializeField]
        private ScriptableSource _source;

        [SerializeField]
        private int _prepoolAmount;

        public Transform Parent { get; set; }

        public ScriptableSource Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _source = value;
        }

        public int PrepoolAmount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolAmount;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolAmount = value;
        }

        public async UniTask<UnityEngine.Object> Instantiate()
        {
            if (_source is null)
                throw new NullReferenceException(nameof(Source));

            return await _source.Instantiate(Parent);
        }

        public async UniTask<UnityEngine.Object> Instantiate(CancellationToken cancelToken)
        {
            if (_source is null)
                throw new NullReferenceException(nameof(Source));

            return await _source.Instantiate(Parent, cancelToken);
        }

        public void Release(UnityEngine.Object instance)
        {
            if (instance && _source)
                _source.Release(instance);
        }
    }
}
