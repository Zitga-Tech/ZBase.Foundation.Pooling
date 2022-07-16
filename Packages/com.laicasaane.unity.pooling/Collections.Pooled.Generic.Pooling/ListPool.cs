﻿using System;
using System.Buffers;
using System.Pooling;

namespace Collections.Pooled.Generic.Pooling
{
    public sealed class ListPool<T> : PoolBase<List<T>>
    {
        public static readonly ListPool<T> Shared = new ListPool<T>();

        public ListPool()
            : base(Instantiate, ArrayPool<List<T>>.Shared)
        { }

        public ListPool(Func<List<T>> instantiate)
            : base(instantiate, ArrayPool<List<T>>.Shared)
        { }

        public ListPool(ArrayPool<List<T>> pool)
            : base(Instantiate, pool)
        { }

        public ListPool(Func<List<T>> instantiate, ArrayPool<List<T>> pool)
            : base(instantiate, pool)
        { }

        protected override Func<List<T>> GetDefaultInstantiator()
            => Instantiate;

        private static List<T> Instantiate()
            => new List<T>();
    }
}
