using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling.Components
{
    [Serializable]
    public abstract class Prefab<TKey, T> : Prefab<T>, IPrefab<TKey, T>
        where T : class
    {
        [SerializeReference]
        private TKey _key;

        public TKey Key
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _key;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _key = value;
        }
    }
}
