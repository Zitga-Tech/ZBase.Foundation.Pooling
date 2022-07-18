using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public abstract partial class AsyncPoolBase<T> : IAsyncPool<T>, IAsyncInstantiatorSetable<T>, IDisposable
        where T : class
    {
        private readonly UniqueQueue<T> _queue;
        private UniTaskFunc<T> _instantiate;

        public AsyncPoolBase()
            : this(null, null)
        { }

        public AsyncPoolBase(UniqueQueue<T> queue)
            : this(queue, null)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate)
            : this(null, instantiate)
        { }

        public AsyncPoolBase(UniqueQueue<T> queue, UniTaskFunc<T> instantiate)
        {
            _queue = queue ?? new UniqueQueue<T>();
            _instantiate = instantiate ?? GetDefaultInstantiator() ?? DefaultAsyncInstantiator<T>.Get();
        }

        public void SetInstantiator(UniTaskFunc<T> instantiator)
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

        protected virtual UniTaskFunc<T> GetDefaultInstantiator() => DefaultAsyncInstantiator<T>.Get();
    }
}
