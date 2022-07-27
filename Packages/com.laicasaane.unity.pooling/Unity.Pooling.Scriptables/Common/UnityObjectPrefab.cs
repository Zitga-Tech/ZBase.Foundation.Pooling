using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
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

            return await _source.InstantiateAsync(Parent);
        }
    }
}
