using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class PoolBehaviourBase<TKey, T, TPool>
        : MonoBehaviour, IPool<TKey, T>
        where T : class
        where TPool : IPool<TKey, T>
    {
        [SerializeField]
        private TPool _pool;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count(TKey key)
            => _pool.Count(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
            => _pool.ReleaseInstances(key, keep, onReleased);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Rent(TKey key)
            => _pool.Rent(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(TKey key, T instance)
            => _pool.Return(key,instance);

        protected virtual void OnDestroy()
        {
            if (_pool is IDisposable disposable)
                disposable.Dispose();
        }
    }
}
