using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public abstract class PoolComponentBase<TKey, T, TPrefab, TPool>
        : MonoBehaviour, IPoolComponent<TKey, T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<TKey, T>
        where TPool : IUnityPool<TKey, T>, IInstantiatorSetable<T>, IDisposable, new()
    {
        [SerializeField]
        private TPrefab _prefab;

        private readonly UnityPrepooler<TKey, T, TPrefab, TPool> _prepooling = new();
        private readonly UnityInstantiator<T, TPrefab> _instantiator = new();
        private TPool _pool;

        public TPrefab Prefab
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab;
        }

        public TPool Pool
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _pool;
        }

        protected virtual void Awake()
        {
            _pool = new TPool();
            _pool.SetInstantiator(Instantiate);
        }

        protected virtual void OnDestroy()
        {
            _pool.Dispose();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T Instantiate()
            => _instantiator.Instantiate(_prefab, this.transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask Prepool()
            => await _prepooling.Prepool(_prefab, _pool, this.transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
            => _pool.ReleaseInstances(key, keep, onReleased ?? ReleaseInstance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(TKey key, T instance)
            => _pool.Return(key, instance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count(TKey key)
            => _pool.Count(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Rent(TKey key, string name)
            => _pool.Rent(key, name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Rent(TKey key)
            => _pool.Rent(key);

        protected abstract void ReleaseInstance(T instance);
    }
}
