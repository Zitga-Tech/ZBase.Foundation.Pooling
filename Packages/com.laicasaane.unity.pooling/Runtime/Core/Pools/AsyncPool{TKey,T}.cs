using System.Buffers;
using Collections.Pooled;
using Collections.Pooled.Generic;

namespace Unity.Pooling
{
    public sealed class AsyncPool<TKey, T> : AsyncPoolBase<TKey, T>
        where T : class, new()
    {
        public static readonly AsyncPool<TKey, T> Shared = new AsyncPool<TKey, T>();

        public AsyncPool()
            : base(Instantiator.Instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPool(ArrayPool<T> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : base(instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
            : base(instantiate, pool, ArrayPool<int>.Shared, ArrayPool<Entry<TKey, Queue<T>>>.Shared)
        { }

        public AsyncPool(ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : base(Instantiator.Instantiate, pool, poolBucket, poolEntry)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate, ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : base(instantiate, pool, poolBucket, poolEntry)
        { }
    }
}
