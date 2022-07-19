using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling.Components
{
    [Serializable]
    public class UnityPrefab<TKey, T> : IUnityPrefab<TKey, T>
        where T : UnityEngine.Object
    {
        [SerializeReference]
        private TKey _key;

        [SerializeField]
        private T _prefab;

        [SerializeField]
        private int _prepoolingAmount;

        [SerializeField]
        private PrepoolTiming _prepoolTiming = PrepoolTiming.NextFrame;

        [SerializeField]
        private Transform _parent;

        public TKey Key
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _key;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _key = value;
        }

        public T Prefab
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prefab = value;
        }

        public int PrepoolingAmount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolingAmount;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolingAmount = value;
        }

        public PrepoolTiming PrepoolTiming
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolTiming;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolTiming = value;
        }

        public Transform Parent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _parent;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _parent = value;
        }
    }
}
