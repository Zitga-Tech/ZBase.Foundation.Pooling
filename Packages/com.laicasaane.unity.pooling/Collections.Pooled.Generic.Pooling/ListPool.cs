using System;
using System.Buffers;
using System.Pooling;
using System.Runtime.CompilerServices;

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override Func<List<T>> GetInstantiator()
            => Instantiate;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(List<T> instance)
            => instance.Clear();

        private static List<T> Instantiate()
            => new List<T>();
    }
}
