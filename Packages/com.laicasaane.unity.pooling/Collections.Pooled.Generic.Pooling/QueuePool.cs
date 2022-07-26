using System;
using System.Pooling;
using System.Runtime.CompilerServices;

namespace Collections.Pooled.Generic.Pooling
{
    public sealed class QueuePool<T> : PoolBase<Queue<T>>
    {
        public static readonly QueuePool<T> Shared = new QueuePool<T>();

        public QueuePool()
            : base(Instantiate)
        { }

        public QueuePool(UniqueQueue<Queue<T>> queue)
            : base(queue, Instantiate)
        { }

        public QueuePool(Func<Queue<T>> instantiate)
            : base(null, instantiate ?? Instantiate)
        { }

        public QueuePool(UniqueQueue<Queue<T>> queue, Func<Queue<T>> instantiate)
            : base(queue, instantiate ?? Instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Queue<T> instance)
            => instance.Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Queue<T> Instantiate()
            => new Queue<T>();
    }
}
