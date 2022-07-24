using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public abstract class AsyncPoolBehaviourBase<TKey, T, TPool>
        : MonoBehaviour, IAsyncPool<TKey, T>
        where T : class
        where TPool : IAsyncPool<TKey, T>
    {
        [SerializeField]
        private TPool _pool;

        protected TPool Pool
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count(TKey key)
            => _pool.Count(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
            => _pool.ReleaseInstances(key, keep, onReleased);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> RentAsync(TKey key)
            => await _pool.RentAsync(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(TKey key, T instance)
            => _pool.Return(key, instance);

        protected virtual void OnDestroy()
        {
            if (_pool is IDisposable disposable)
                disposable.Dispose();
        }
    }
}
