using System;
using System.Buffers;

namespace Unity.Pooling
{
    public sealed class Pool<T> : PoolBase<T>
        where T : class
    {
        public static readonly Pool<T> Shared = new Pool<T>();

        public Pool()
            : base(Instantiator.Instantiate, ArrayPool<T>.Shared)
        { }

        public Pool(Func<T> instantiate)
            : base(instantiate, ArrayPool<T>.Shared)
        { }

        public Pool(ArrayPool<T> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public Pool(Func<T> instantiate, ArrayPool<T> pool)
            : base(instantiate, pool)
        { }
    }
}
