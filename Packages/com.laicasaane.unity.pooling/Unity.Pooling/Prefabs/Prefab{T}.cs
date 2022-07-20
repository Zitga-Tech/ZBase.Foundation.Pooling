using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class Prefab<T, TSource, TPrefabSource> : IPrefab<T, TSource, TPrefabSource>
        where T : class
        where TPrefabSource : ILoadableSource<TSource, T>
    {
        [SerializeField]
        private TPrefabSource _source;

        [SerializeField]
        private int _prepoolAmount;

        [SerializeField]
        private Timing _prepoolTiming = Timing.NextFrame;

        [SerializeField]
        private Transform _parent;

        public TPrefabSource Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _source = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int PrepoolAmount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolAmount;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolAmount = value;
        }

        public Timing PrepoolTiming
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
            set => _parent = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
