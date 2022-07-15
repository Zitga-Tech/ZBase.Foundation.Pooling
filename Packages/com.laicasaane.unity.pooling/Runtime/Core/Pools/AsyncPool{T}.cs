using System;
using System.Buffers;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public class AsyncPool<T> : IAsyncPool<T>, IDisposable
        where T : class
    {
        public static readonly AsyncPool<T> Shared = new AsyncPool<T>();

        private readonly UniTaskFunc<T> _instantiate;
        private readonly Queue<T> _queue;

        public AsyncPool()
            : this(Instantiator.Instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPool(ArrayPool<T> pool)
            : this(Instantiator.Instantiate, pool)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
        {
            _instantiate = instantiate ?? Instantiator.Instantiate;
            _queue = new Queue<T>(pool ?? ArrayPool<T>.Shared);
        }

        public int Count() => _queue.Count;

        public AsyncDisposableContext<T> Poolable()
            => new AsyncDisposableContext<T>(this);

        public void Dispose()
        {
            _queue.Dispose();
        }

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

        public void Return(T instance)
        {
            ReturnPreprocess(instance);
            _queue.Enqueue(instance);
        }

        protected virtual void ReturnPreprocess(T instance) { }

        private static class Instantiator
        {
            private static readonly Type s_type = typeof(T);

            public static async UniTask<T> Instantiate()
            {
                var result = (T)Activator.CreateInstance(s_type);
                return await UniTask.FromResult(result);
            }
        }
    }
}
