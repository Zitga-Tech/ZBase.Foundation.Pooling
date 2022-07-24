using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using Collections.Pooled.Generic.Internals.Unsafe;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public abstract partial class AsyncPoolBase<TKey, T> : IAsyncPool<TKey, T>, IAsyncInstantiatorSetable<T>, IDisposable
        where T : class
    {
        private readonly Dictionary<TKey, UniqueQueue<T>> _queueMap;
        private readonly Func<UniqueQueue<T>> _queueInstantiate;
        private UniTaskFunc<T> _instantiate;

        public AsyncPoolBase()
            : this(null, null, null)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate)
            : this(null, null, instantiate)
        { }

        public AsyncPoolBase(Dictionary<TKey, UniqueQueue<T>> queueMap , Func<UniqueQueue<T>> queueInstantiate)
            : this(queueMap, queueInstantiate, null)
        { }

        public AsyncPoolBase(Dictionary<TKey, UniqueQueue<T>>  queueMap
            , Func<UniqueQueue<T>> queueInstantiate
            , UniTaskFunc<T> instantiate
        )
        {
            _queueMap = queueMap ?? new Dictionary<TKey, UniqueQueue<T>>();
            _queueInstantiate = queueInstantiate ?? NewInstancer<UniqueQueue<T>>.Instantiate;
            _instantiate = instantiate ?? GetDefaultInstantiator() ?? DefaultAsyncInstantiator<T>.Get();
        }

        public void SetInstantiator(UniTaskFunc<T> instantiator)
            => _instantiate = instantiator ?? GetDefaultInstantiator();

        public int Count(TKey key)
        {
            if (key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

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
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

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

        public async UniTask<T> RentAsync(TKey key)
        {
            if (key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

            if (_queueMap.TryGetValue(key, out var queue)
                && queue.TryDequeue(out var instance))
                return instance;

            return await _instantiate();
        }

        public void Return(TKey key, T instance)
        {
            if (key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

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

        protected virtual UniTaskFunc<T> GetDefaultInstantiator() => DefaultAsyncInstantiator<T>.Get();
    }
}
