using System.Buffers;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public abstract partial class AsyncPoolBase<T> : IAsyncPool<T>, IDisposable
        where T : class
    {
        private readonly UniTaskFunc<T> _instantiate;
        private readonly Queue<T> _queue;

        public AsyncPoolBase()
            : this(null, ArrayPool<T>.Shared)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPoolBase(ArrayPool<T> pool)
            : this(null, pool)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
        {
            _instantiate = instantiate ?? GetInstantiator() ?? DefaultAsyncInstantiator<T>.Get();
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }

        protected virtual UniTaskFunc<T> GetInstantiator() => DefaultAsyncInstantiator<T>.Get();
    }
}
