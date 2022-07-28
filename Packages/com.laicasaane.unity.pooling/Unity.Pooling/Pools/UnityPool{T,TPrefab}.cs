using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class UnityPool<T, TPrefab>
        : IUnityPool<T>, IHasPrefab<TPrefab>, IDisposable
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T>
    {
        private readonly UniqueQueue<int, T> _queue;

        [SerializeField]
        private TPrefab _prefab;

        public UnityPool()
        {
            _queue = new UniqueQueue<int, T>();
        }

        public UnityPool(TPrefab prefab)
        {
            _queue = new UniqueQueue<int, T>();
            _prefab = prefab ?? throw new ArgumentNullException(nameof(prefab));
        }

        public UnityPool(UniqueQueue<int, T> queue, TPrefab prefab)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _prefab = prefab ?? throw new ArgumentNullException(nameof(prefab));
        }

        public TPrefab Prefab
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prefab = value;
        }

        public int Count() => _queue.Count;

        public void Dispose()
        {
            _queue.Dispose();
        }

        /// <inheritdoc/>
        public void ReleaseInstances(int keep, Action<T> onReleased = null)
        {
            var countRemove = _queue.Count - keep;

            while (countRemove > 0)
            {
                var instance = _queue.Dequeue();
                onReleased?.Invoke(instance.Value);
                countRemove--;
            }
        }

        public async UniTask<T> Rent()
        {
            if (_queue.TryDequeue(out var instance))
                return instance.Value;

            return await _prefab.Instantiate();
        }

        public void Return(T instance)
        {
            if (instance == false)
                return;

            ReturnPreprocess(instance);
            _queue.Enqueue(instance.ToKVPair());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }
    }
}
