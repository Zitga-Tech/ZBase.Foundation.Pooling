using System.Buffers;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;

namespace System.Pooling
{
    public abstract class PoolBase<T> : IPool<T>, IDisposable
        where T : class
    {
        private readonly Func<T> _instantiate;
        private readonly Queue<T> _queue;

        public PoolBase()
            : this(null, ArrayPool<T>.Shared)
        { }

        public PoolBase(Func<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public PoolBase(ArrayPool<T> pool)
            : this(null, pool)
        { }

        public PoolBase(Func<T> instantiate, ArrayPool<T> pool)
        {
            _instantiate = instantiate ?? GetInstantiator() ?? DefaultInstantiator<T>.Get();
            _queue = new Queue<T>(pool ?? ArrayPool<T>.Shared);
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

        public void Return<TEnumerable>(TEnumerable instances)
            where TEnumerable : System.Collections.Generic.IEnumerable<T>
        {
            foreach (var instance in instances)
            {
                Return(instance);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }

        protected virtual Func<T> GetInstantiator() => DefaultInstantiator<T>.Get();
    }
}
