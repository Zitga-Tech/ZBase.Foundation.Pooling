using System.Buffers;
using Collections.Pooled;
using Collections.Pooled.Generic;

namespace System.Pooling
{
    public sealed class Pool<TKey, T> : PoolBase<TKey, T>
        where T : class
    {
        public static readonly Pool<TKey, T> Shared = new Pool<TKey, T>();

        public Pool()
            : base(null, ArrayPool<T>.Shared)
        { }

        public Pool(ArrayPool<T> pool)
            : base(null, pool)
        { }

        public Pool(Func<T> instantiate)
            : base(instantiate, ArrayPool<T>.Shared)
        { }

        public Pool(Func<T> instantiate, ArrayPool<T> pool)
            : base(instantiate, pool, ArrayPool<int>.Shared, ArrayPool<Entry<TKey, Queue<T>>>.Shared)
        { }

        public Pool(ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : base(null, pool, poolBucket, poolEntry)
        { }

        public Pool(Func<T> instantiate, ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : base(instantiate, pool, poolBucket, poolEntry)
        { }
    }
}
