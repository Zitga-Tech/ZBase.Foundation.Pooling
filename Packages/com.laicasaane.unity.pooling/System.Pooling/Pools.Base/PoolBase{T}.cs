using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public abstract partial class PoolBase<T> : IPool<T>, IInstantiatorSetable<T>, IDisposable
        where T : class
    {
        private readonly UniqueQueue<T> _queue;
        private Func<T> _instantiate;

        public PoolBase()
            : this(null, null)
        { }

        public PoolBase(UniqueQueue<T> queue)
            : this(queue, null)
        { }

        public PoolBase(Func<T> instantiate)
            : this(null, instantiate)
        { }

        public PoolBase(UniqueQueue<T> queue, Func<T> instantiate)
        {
            _queue = queue ?? new UniqueQueue<T>();
            _instantiate = instantiate ?? GetDefaultInstantiator() ?? DefaultInstantiator<T>.Get();
        }

        public void SetInstantiator(Func<T> instantiator)
            => _instantiate = instantiator ?? GetDefaultInstantiator();

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
                var instance = _queue.Dequeue();
                onReleased?.Invoke(instance);
                countRemove--;
            }
        }

        public T Rent()
        {
            if (_queue.Count > 0)
                return _queue.Dequeue();

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

        protected virtual Func<T> GetDefaultInstantiator() => DefaultInstantiator<T>.Get();
    }
}
