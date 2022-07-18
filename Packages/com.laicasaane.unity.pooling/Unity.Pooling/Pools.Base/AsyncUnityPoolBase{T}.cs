using System;
using System.Pooling;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public abstract partial class AsyncUnityPoolBase<T> : IAsyncUnityPool<T>, IAsyncInstantiatorSetable<T>, IDisposable
        where T : UnityEngine.Object
    {
        private readonly Queue<T> _queue;
        private UniTaskFunc<T> _instantiate;

        public AsyncUnityPoolBase()
            : this(null)
        { }

        public AsyncUnityPoolBase(UniTaskFunc<T> instantiate)
        {
            _queue = new Queue<T>();
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
            _queue.Enqueue(instance);
        }

        protected abstract void ReturnPreprocess(T instance);

        protected abstract UniTaskFunc<T> GetDefaultInstantiator();
    }
}
