using System;
using System.Buffers;
using System.Pooling;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public abstract partial class AsyncUnityPoolBase<T> : IAsyncPool<T>, IAsyncNamedRentable<T>, IDisposable
        where T : UnityEngine.Object
    {
        private readonly UniTaskFunc<T> _instantiate;
        private readonly Queue<T> _queue;

        public AsyncUnityPoolBase()
            : this(null, ArrayPool<T>.Shared)
        { }

        public AsyncUnityPoolBase(UniTaskFunc<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncUnityPoolBase(ArrayPool<T> pool)
            : this(null, pool)
        { }

        public AsyncUnityPoolBase(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
        {
            _instantiate = instantiate ?? GetInstantiator();
            _queue = new Queue<T>(pool ?? ArrayPool<T>.Shared);
        }

        public int Count() => _queue.Count;

        public AsyncDisposableContext<T> Poolable()
            => new AsyncDisposableContext<T>(this);

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
                onReleased?.Invoke(instance);
                countRemove--;
            }
        }

        public async UniTask<T> RentAsync()
        {
            if (_queue.Count > 0)
                return _queue.Dequeue();

            return await _instantiate();
        }

        public async UniTask<T> RentAsync(string name)
        {
            var instance = await RentAsync();
            instance.name = name;
            return instance;
        }

        public void Return(T instance)
        {
            if (instance == false)
                return;

            ReturnPreprocess(instance);
            _queue.Enqueue(instance);
        }

        protected abstract void ReturnPreprocess(T instance);

        protected abstract UniTaskFunc<T> GetInstantiator();
    }
}
