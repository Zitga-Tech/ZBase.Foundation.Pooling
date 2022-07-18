using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public abstract class AsyncUnityPoolComponentBase<T, TPrefab, TPool>
        : MonoBehaviour, IAsyncUnityPoolComponent<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<T>
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

        protected virtual void Start()
        {
            _pool = new TPool();
            _pool.SetInstantiator(InstantiateAsync);

            Initialize();
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

            for (int i = 0, count = prefab.PrepoolingAmount; i < count; i++)
            {
                var instance = Instantiate(prefabObject);
                _pool.Return(instance);

                await UniTask.Yield(timing);
            }
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

        protected virtual void Initialize() { }

        protected abstract UniTask<T> InstantiateAsync();

        protected abstract void ReleaseInstance(T instance);
    }
}
