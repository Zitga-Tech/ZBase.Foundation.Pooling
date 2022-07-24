using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class PoolBehaviourBase<T, TPool>
        : MonoBehaviour, IPool<T>
        where T : class
        where TPool : IPool<T>
    {
        [SerializeField]
        private TPool _pool;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count()
            => _pool.Count();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseInstances(int keep, Action<T> onReleased = null)
            => _pool.ReleaseInstances(keep, onReleased);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Rent()
            => _pool.Rent();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(T instance)
            => _pool.Return(instance);

        protected virtual void OnDestroy()
        {
            if (_pool is IDisposable disposable)
                disposable.Dispose();
        }
    }
}
