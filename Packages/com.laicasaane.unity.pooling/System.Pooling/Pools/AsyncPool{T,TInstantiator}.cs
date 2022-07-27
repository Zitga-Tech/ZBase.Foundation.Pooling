using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public class AsyncPool<T, TInstantiator> : IAsyncPool<T>, IDisposable
        where T : class
        where TInstantiator : IAsyncInstantiable<T>, new()
    {
        private readonly TInstantiator _instantiator;
        private readonly UniqueQueue<T> _queue;

        public AsyncPool()
            : this(null)
        { }

        public AsyncPool(UniqueQueue<T> queue)
        {
            _instantiator = new TInstantiator();
            _queue = queue ?? new UniqueQueue<T>();
        }

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

        public async UniTask<T> Rent()
        {
            if (_queue.TryDequeue(out var instance))
                return instance;

            return await _instantiator.Instantiate();
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
