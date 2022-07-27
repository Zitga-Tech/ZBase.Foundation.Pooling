using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public class AsyncPool<T> : IAsyncPool<T>, IAsyncSetInstantiator<T>, IDisposable
        where T : class
    {
        private readonly UniqueQueue<T> _queue;
        private UniTaskFunc<T> _instantiate;

        public AsyncPool()
            : this(null, null)
        { }

        public AsyncPool(UniqueQueue<T> queue)
            : this(queue, null)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : this(null, instantiate)
        { }

        public AsyncPool(UniqueQueue<T> queue, UniTaskFunc<T> instantiate)
        {
            _queue = queue ?? new UniqueQueue<T>();
            _instantiate = instantiate ?? DefaultAsyncInstantiator<T>.Get();
        }

        public void SetInstantiator(UniTaskFunc<T> instantiator)
            => _instantiate = instantiator ?? DefaultAsyncInstantiator<T>.Get();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                if (_queue.TryDequeue(out var instance))
                    onReleased?.Invoke(instance);

                countRemove--;
            }
        }

        public async UniTask<T> RentAsync()
        {
            if (_queue.TryDequeue(out var instance))
                return instance;

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
    }
}
