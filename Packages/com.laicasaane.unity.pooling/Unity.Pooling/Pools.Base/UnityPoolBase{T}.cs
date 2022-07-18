using System;
using System.Pooling;

namespace Unity.Pooling
{
    public abstract partial class UnityPoolBase<T> : IUnityPool<T>, IInstantiatorSetable<T>, IDisposable
        where T : UnityEngine.Object
    {
        private readonly UniqueQueue<T> _queue;
        private Func<T> _instantiate;

        public UnityPoolBase()
            : this(null, null)
        { }

        public UnityPoolBase(UniqueQueue<T> queue)
            : this(queue, null)
        { }

        public UnityPoolBase(Func<T> instantiate)
            : this(null, instantiate)
        { }

        public UnityPoolBase(UniqueQueue<T> queue, Func<T> instantiate)
        {
            _queue = queue ?? new UniqueQueue<T>();
            _instantiate = instantiate ?? GetDefaultInstantiator() ?? DefaultInstantiator<T>.Get();
        }

        public void SetInstantiator(Func<T> instantiator)
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

        public T Rent()
        {
            if (_queue.Count > 0)
                return _queue.Dequeue();

            return _instantiate();
        }

        public T Rent(string name)
        {
            var instance = Rent();
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

        protected abstract Func<T> GetDefaultInstantiator();
    }
}
