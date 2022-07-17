using System;
using System.Buffers;
using System.Pooling;
using System.Runtime.CompilerServices;

namespace Collections.Pooled.Generic.Pooling
{
    public sealed class QueuePool<T> : PoolBase<Queue<T>>
    {
        public static readonly QueuePool<T> Shared = new QueuePool<T>();

        public QueuePool()
            : base(Instantiate, ArrayPool<Queue<T>>.Shared)
        { }

        public QueuePool(Func<Queue<T>> instantiate)
            : base(instantiate, ArrayPool<Queue<T>>.Shared)
        { }

        public QueuePool(ArrayPool<Queue<T>> pool)
            : base(Instantiate, pool)
        { }

        public QueuePool(Func<Queue<T>> instantiate, ArrayPool<Queue<T>> pool)
            : base(instantiate, pool)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override Func<Queue<T>> GetInstantiator()
            => Instantiate;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Queue<T> instance)
            => instance.Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Queue<T> Instantiate()
            => new Queue<T>();
    }
}
