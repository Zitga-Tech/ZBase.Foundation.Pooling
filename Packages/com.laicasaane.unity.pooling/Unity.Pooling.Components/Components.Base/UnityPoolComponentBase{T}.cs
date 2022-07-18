using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public abstract class UnityPoolComponentBase<T, TPrefab, TPool>
        : MonoBehaviour, IUnityPoolComponent<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<T>
        where TPool : IUnityPool<T>, IInstantiatorSetable<T>, IDisposable, new()
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
            _pool.SetInstantiator(Instantiate);
        }

        protected virtual void OnDestroy()
        {
            _pool.Dispose();
        }

        private T Instantiate()
        {
            if (_prefab.Validate() == false)
                throw new InvalidOperationException(nameof(_prefab));

            return Instantiate(_prefab.Prefab);
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
