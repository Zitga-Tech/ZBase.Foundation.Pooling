using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public class Pool<T, TInstantiator> : IPool<T>, IShareable, IDisposable
        where T : class
        where TInstantiator : IInstantiable<T>, new()
    {
        private readonly TInstantiator _instantiator = new TInstantiator();
        private readonly UniqueQueue<T> _queue;

        public Pool()
        {
            _queue = new UniqueQueue<T>();
        }

        public Pool(UniqueQueue<T> queue)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
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

        public T Rent()
        {
            if (_queue.TryDequeue(out var instance))
                return instance;

            return _instantiator.Instantiate();
        }

        public void Return(T instance)
        {
            if (instance is null)
                return;

            ReturnPreprocess(instance);
            _queue.TryEnqueue(instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }
    }
}
