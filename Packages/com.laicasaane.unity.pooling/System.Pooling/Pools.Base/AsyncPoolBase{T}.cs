using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public abstract partial class AsyncPoolBase<T> : IAsyncPool<T>, IAsyncInstantiatorSetable<T>, IDisposable
        where T : class
    {
        private readonly Queue<T> _queue;
        private UniTaskFunc<T> _instantiate;

        public AsyncPoolBase()
            : this(null)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate)
        {
            _queue = new Queue<T>();
            _instantiate = instantiate ?? GetDefaultInstantiator() ?? DefaultAsyncInstantiator<T>.Get();
        }

        public void SetInstantiator(UniTaskFunc<T> instantiator)
            => _instantiate = instantiator ?? GetDefaultInstantiator();

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

        public async UniTask<T> RentAsync()
        {
            if (_queue.Count > 0)
                return _queue.Dequeue();

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
