using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public abstract class AsyncPoolComponentBase<T, TPrefab, TPool>
        : MonoBehaviour, IAsyncPoolComponent<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IPrefab
        where TPool : IAsyncUnityPool<T>, IAsyncInstantiatorSetable<T>, IDisposable, new()
    {
        [SerializeField]
        private TPrefab _prefab;

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
            _pool.SetInstantiator(InstantiateAsync);
        }

        protected virtual void OnDestroy()
        {
            _pool.Dispose();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseInstances(int keep, Action<T> onReleased = null)
            => _pool.ReleaseInstances(keep, onReleased ?? ReleaseInstance);

        public async UniTask<T> RentAsync()
            => await _pool.RentAsync();

        public async UniTask<T> RentAsync(string name)
            => await _pool.RentAsync(name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(T instance)
            => _pool.Return(instance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count()
            => _pool.Count();

        public abstract UniTask Prepool();

        protected abstract UniTask<T> InstantiateAsync();

        protected abstract void ReleaseInstance(T instance);
    }
}
