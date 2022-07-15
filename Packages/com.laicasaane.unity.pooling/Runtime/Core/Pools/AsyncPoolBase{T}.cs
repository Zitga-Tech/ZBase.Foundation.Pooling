using System;
using System.Buffers;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public abstract class AsyncPoolBase<T> : IAsyncPool<T>, IDisposable
        where T : class
    {
        private readonly UniTaskFunc<T> _instantiate;
        private readonly Queue<T> _queue;

        public AsyncPoolBase()
            : this(Instantiator.Instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPoolBase(ArrayPool<T> pool)
            : this(Instantiator.Instantiate, pool)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
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
            if (instance is null)
                return;

            ReturnPreprocess(instance);
            _queue.Enqueue(instance);
        }

        protected virtual void ReturnPreprocess(T instance) { }

        protected static class Instantiator
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
