using System;
using System.Pooling;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public abstract partial class AsyncUnityPoolBase<T, S, TSource, TPrefab>
        : IAsyncUnityPool<T, S, TSource, TPrefab>, IAsyncInstantiatorSetable<T>, IDisposable
        where T : UnityEngine.Object
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
    {
        private readonly UniqueQueue<int, T> _queue;
        private UniTaskFunc<T> _instantiate;

        public AsyncUnityPoolBase()
            : this(null, null)
        { }

        public AsyncUnityPoolBase(UniqueQueue<int, T> queue)
            : this(queue, null)
        { }

        public AsyncUnityPoolBase(UniTaskFunc<T> instantiate)
            : this(null, instantiate)
        { }

        public AsyncUnityPoolBase(UniqueQueue<int, T> queue, UniTaskFunc<T> instantiate)
        {
            _queue = queue ?? new UniqueQueue<int, T>();
            _instantiate = instantiate ?? GetDefaultInstantiator();
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
                onReleased?.Invoke(instance.Value);
                countRemove--;
            }
        }

        public async UniTask<T> RentAsync()
        {
            if (_queue.TryDequeue(out var instance))
                return instance.Value;

            return await _instantiate();
        }

        public async UniTask<T> RentAsync(string name)
        {
            var instance = await RentAsync();
            instance.name = name.NameOfIfNullOrEmpty<T>();
            return instance;
        }

        public void Return(T instance)
        {
            if (instance == false)
                return;

            ReturnPreprocess(instance);
            _queue.Enqueue(instance.ToKVPair());
        }

        protected abstract void ReturnPreprocess(T instance);

        protected abstract UniTaskFunc<T> GetDefaultInstantiator();
    }
}
