using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public class Pool<T> : IPool<T>, ISetInstantiator<T>, IDisposable
        where T : class
    {
        private readonly UniqueQueue<T> _queue;
        private Func<T> _instantiate;

        public Pool()
            : this(null, null)
        { }

        public Pool(UniqueQueue<T> queue)
            : this(queue, null)
        { }

        public Pool(Func<T> instantiate)
            : this(null, instantiate)
        { }

        public Pool(UniqueQueue<T> queue, Func<T> instantiate)
        {
            _queue = queue ?? new UniqueQueue<T>();
            _instantiate = instantiate ?? DefaultInstantiator<T>.Get();
        }

        public void SetInstantiator(Func<T> instantiator)
            => _instantiate = instantiator ?? DefaultInstantiator<T>.Get();

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

            return _instantiate();
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
