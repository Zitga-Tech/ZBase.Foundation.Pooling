using System;
using System.Pooling;
using Collections.Pooled.Generic;
using Collections.Pooled.Generic.Internals.Unsafe;

namespace Unity.Pooling
{
    public abstract partial class UnityPoolBase<TKey, T> : IUnityPool<TKey, T>, IInstantiatorSetable<T>, IDisposable
        where T : UnityEngine.Object
    {
        private readonly Dictionary<TKey, UniqueQueue<T>> _queueMap;
        private readonly Func<UniqueQueue<T>> _queueInstantiate;
        private Func<T> _instantiate;

        public UnityPoolBase()
            : this(null, null, null)
        { }

        public UnityPoolBase(Func<T> instantiate)
            : this(null, null, instantiate)
        { }

        public UnityPoolBase(Dictionary<TKey, UniqueQueue<T>> queueMap, Func<UniqueQueue<T>> queueInstantiate)
            : this(queueMap, queueInstantiate, null)
        { }

        public UnityPoolBase(Dictionary<TKey, UniqueQueue<T>> queueMap
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
                {
                    entry.Value?.Dispose();
                }
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
                    var instance = queue.Dequeue();
                    onReleased?.Invoke(instance);
                    countRemove--;
                }
            }
        }

        public T Rent(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue))
            {
                if (queue.Count > 0)
                    return queue.Dequeue();
            }

            return _instantiate();
        }

        public T Rent(TKey key, string name)
        {
            var instance = Rent(key);
            instance.name = name.NameOfIfNullOrEmpty<T>();
            return instance;
        }

        public void Return(TKey key, T instance)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (instance == false)
                return;

            if (_queueMap.TryGetValue(key, out var queue) == false)
            {
                queue = _queueInstantiate();
                _queueMap[key] = queue;
            }

            ReturnPreprocess(instance);
            queue.Enqueue(instance);
        }

        protected abstract void ReturnPreprocess(T instance);

        protected abstract Func<T> GetDefaultInstantiator();
    }
}
