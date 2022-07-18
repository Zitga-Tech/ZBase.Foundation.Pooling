using Collections.Pooled.Generic;

namespace System.Pooling
{
    public sealed class Pool<TKey, T> : PoolBase<TKey, T>
        where T : class
    {
        public static readonly Pool<TKey, T> Shared = new Pool<TKey, T>();

        public Pool()
            : base(null, null, null)
        { }

        public Pool(Func<T> instantiate)
            : base(null, null, instantiate)
        { }

        public Pool(Dictionary<TKey, UniqueQueue<T>> queueMap, Func<UniqueQueue<T>> queueInstantiate)
            : base(queueMap, queueInstantiate, null)
        { }

        public Pool(Dictionary<TKey, UniqueQueue<T>> queueMap
            , Func<UniqueQueue<T>> queueInstantiate
            , Func<T> instantiate
        )
            : base(queueMap, queueInstantiate, instantiate)
        { }
    }
}
