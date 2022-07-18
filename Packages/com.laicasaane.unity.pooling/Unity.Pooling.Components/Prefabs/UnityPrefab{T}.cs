using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling.Components
{
    [Serializable]
    public class UnityPrefab<T>  : IUnityPrefab<T>
        where T : UnityEngine.Object
    {
        [SerializeField]
        private T _prefab;

        [SerializeField]
        private int _prepoolingAmount;

        [SerializeField]
        private PrepoolTiming _prepoolTiming = PrepoolTiming.Update;

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
    }
}
