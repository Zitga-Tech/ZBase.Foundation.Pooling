using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class Prefab<TKey, T, TSource, TPrefabSource>
        : Prefab<T, TSource, TPrefabSource>, IPrefab<TKey, T, TSource, TPrefabSource>
        where T : class
        where TPrefabSource : ILoadableSource<TSource, T>
    {
        [SerializeReference]
        private TKey _key;

        public TKey Key
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _key;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _key = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
