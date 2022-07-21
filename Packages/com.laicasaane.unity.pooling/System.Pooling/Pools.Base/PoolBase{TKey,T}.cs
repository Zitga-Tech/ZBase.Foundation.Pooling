using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using Collections.Pooled.Generic.Internals.Unsafe;

namespace System.Pooling
{
    public abstract partial class PoolBase<TKey, T> : IPool<TKey, T>, ISetInstantiator<T>, IDisposable
        where T : class
    {
        private readonly Dictionary<TKey, UniqueQueue<T>> _queueMap;
        private readonly Func<UniqueQueue<T>> _queueInstantiate;
        private Func<T> _instantiate;

        public PoolBase()
            : this(null, null, null)
        { }

        public PoolBase(Func<T> instantiate)
            : this(null, null, instantiate)
        { }

        public PoolBase(Dictionary<TKey, UniqueQueue<T>> queueMap, Func<UniqueQueue<T>> queueInstantiate)
            : this(queueMap, queueInstantiate, null)
        { }

        public PoolBase(Dictionary<TKey, UniqueQueue<T>> queueMap
            , Func<UniqueQueue<T>> queueInstantiate
            , Func<T> instantiate
        )
        {
            _queueMap = queueMap ?? new Dictionary<TKey, UniqueQueue<T>>();
            _queueInstantiate = queueInstantiate ?? NewInstancer<UniqueQueue<T>>.Instantiate;
            _instantiate = instantiate ?? GetDefaultInstantiator() ?? DefaultInstantiator<T>.Get();
        }

        public void SetInstantiator(Func<T> instantiator)
            => _instantiate = instantiator ?? GetDefaultInstantiator();

        public int Count(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue))
                return queue.Count;

            return 0;
        }

        public void Dispose()
        {
            _queueMap.GetUnsafe(out var entries, out var count);

            for (int i = 0; i < count; i++)
            {
                ref var entry = ref entries[i];

                if (entry.Next >= -1)
                    entry.Value?.Dispose();
            }

            _queueMap.Dispose();
        }

        /// <inheritdoc/>
        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue))
            {
                var countRemove = queue.Count - keep;

                while (countRemove > 0)
                {
                    if (queue.TryDequeue(out var instance))
                        onReleased?.Invoke(instance);

                    countRemove--;
                }
            }
        }

        public T Rent(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue)
                && queue.TryDequeue(out var instance))
                return instance;

            return _instantiate();
        }

        public void Return(TKey key, T instance)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (instance is null)
                return;

            if (_queueMap.TryGetValue(key, out var queue) == false)
            {
                queue = _queueInstantiate();
                _queueMap[key] = queue;
            }

            ReturnPreprocess(instance);
            queue.Enqueue(instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }

        protected virtual Func<T> GetDefaultInstantiator() => DefaultInstantiator<T>.Get();
    }
}
