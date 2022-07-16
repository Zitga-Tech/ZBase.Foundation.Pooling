using System;
using System.Buffers;

namespace System.Pooling
{
    public sealed class Pool<T> : PoolBase<T>
        where T : class
    {
        public static readonly Pool<T> Shared = new Pool<T>();

        public Pool()
            : base(null, ArrayPool<T>.Shared)
        { }

        public Pool(Func<T> instantiate)
            : base(instantiate, ArrayPool<T>.Shared)
        { }

        public Pool(ArrayPool<T> pool)
            : base(null, pool)
        { }

        public Pool(Func<T> instantiate, ArrayPool<T> pool)
            : base(instantiate, pool)
        { }
    }
}
