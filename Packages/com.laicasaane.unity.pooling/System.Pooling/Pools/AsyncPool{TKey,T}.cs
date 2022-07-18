using Collections.Pooled.Generic;

namespace System.Pooling
{
    public sealed class AsyncPool<TKey, T> : AsyncPoolBase<TKey, T>
        where T : class
    {
        public static readonly AsyncPool<TKey, T> Shared = new AsyncPool<TKey, T>();

        public AsyncPool()
            : base(null, null, null)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : base(null, null, instantiate)
        { }

        public AsyncPool(Dictionary<TKey, UniqueQueue<T>> queueMap, Func<UniqueQueue<T>> queueInstantiate)
            : base(queueMap, queueInstantiate, null)
        { }

        public AsyncPool(Dictionary<TKey, UniqueQueue<T>> queueMap
            , Func<UniqueQueue<T>> queueInstantiate
            , UniTaskFunc<T> instantiate
        )
            : base(queueMap, queueInstantiate, instantiate)
        { }
    }
}
