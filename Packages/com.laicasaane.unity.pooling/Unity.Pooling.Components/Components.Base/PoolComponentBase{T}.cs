using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public abstract class PoolComponentBase<T, TPrefab, TPool>
        : MonoBehaviour, IPoolComponent<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T>
        where TPool : IUnityPool<T>, IInstantiatorSetable<T>, IDisposable, new()
    {
        [SerializeField]
        private TPrefab _prefab;

        private readonly UnityPrepooler<T, TPrefab, TPool> _prepooling = new();
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
        public void ReleaseInstances(int keep, Action<T> onReleased = null)
            => _pool.ReleaseInstances(keep, onReleased ?? ReleaseInstance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(T instance)
            => _pool.Return(instance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count()
            => _pool.Count();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Rent()
            => _pool.Rent();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Rent(string name)
            => _pool.Rent(name);

        protected abstract void ReleaseInstance(T instance);
    }
}
