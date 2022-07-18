using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public abstract class AsyncUnityPoolComponentBase<TKey, T, TPrefab, TPool>
        : MonoBehaviour, IAsyncUnityPoolComponent<TKey, T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<TKey, T>
        where TPool : IAsyncUnityPool<TKey, T>, IAsyncInstantiatorSetable<T>, IDisposable, new()
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

        public async UniTask Prepool()
        {
            if (_pool == null)
                throw new NullReferenceException(nameof(_pool));

            var prefab = Prefab;

            if (prefab.Validate() == false || prefab.PrepoolingAmount <= 0)
                return;

            var timing = prefab.PrepoolTiming.ToPlayerLoopTiming();
            var prefabObject = prefab.Prefab;
            var key = prefab.Key;

            for (int i = 0, count = prefab.PrepoolingAmount; i < count; i++)
            {
                var instance = Instantiate(prefabObject);
                _pool.Return(key, instance);

                await UniTask.Yield(timing);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
            => _pool.ReleaseInstances(key, keep, onReleased ?? ReleaseInstance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> RentAsync(TKey key)
            => await _pool.RentAsync(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> RentAsync(TKey key, string name)
            => await _pool.RentAsync(key, name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(TKey key, T instance)
            => _pool.Return(key, instance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count(TKey key)
            => _pool.Count(key);

        protected abstract UniTask<T> InstantiateAsync();

        protected abstract void ReleaseInstance(T instance);
    }
}
