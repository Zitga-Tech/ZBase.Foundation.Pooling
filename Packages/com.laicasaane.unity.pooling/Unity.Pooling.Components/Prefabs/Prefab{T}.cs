using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling.Components
{
    [Serializable]
    public abstract class Prefab<T> : IPrefab<T>
        where T : class
    {
        [SerializeField]
        private T _source;

        [SerializeField]
        private int _prepoolAmount;

        [SerializeField]
        private Timing _prepoolTiming = Timing.NextFrame;

        [SerializeField]
        private Transform _parent;

        public T Source
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
            set => _parent = value;
        }
    }
}
