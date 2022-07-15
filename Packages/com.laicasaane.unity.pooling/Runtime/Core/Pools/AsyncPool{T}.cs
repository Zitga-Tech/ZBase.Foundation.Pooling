﻿using System.Buffers;

namespace Unity.Pooling
{
    public sealed class AsyncPool<T> : AsyncPoolBase<T>
        where T : class
    {
        public static readonly AsyncPool<T> Shared = new AsyncPool<T>();

        public AsyncPool()
            : base(Instantiator.Instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : base(instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPool(ArrayPool<T> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
            : base(instantiate, pool)
        { }
    }
}
