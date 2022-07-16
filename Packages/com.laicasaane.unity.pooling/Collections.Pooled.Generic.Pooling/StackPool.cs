using System;
using System.Buffers;
using System.Pooling;

namespace Collections.Pooled.Generic.Pooling
{
    public sealed class StackPool<T> : PoolBase<Stack<T>>
    {
        public static readonly StackPool<T> Shared = new StackPool<T>();

        public StackPool()
            : base(Instantiate, ArrayPool<Stack<T>>.Shared)
        { }

        public StackPool(Func<Stack<T>> instantiate)
            : base(instantiate, ArrayPool<Stack<T>>.Shared)
        { }

        public StackPool(ArrayPool<Stack<T>> pool)
            : base(Instantiate, pool)
        { }

        public StackPool(Func<Stack<T>> instantiate, ArrayPool<Stack<T>> pool)
            : base(instantiate, pool)
        { }

        protected override Func<Stack<T>> GetDefaultInstantiator()
            => Instantiate;

        private static Stack<T> Instantiate()
            => new Stack<T>();
    }
}
