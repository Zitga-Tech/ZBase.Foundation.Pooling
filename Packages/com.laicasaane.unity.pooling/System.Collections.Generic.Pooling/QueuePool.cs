using System.Buffers;
using System.Pooling;

namespace System.Collections.Generic.Pooling
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

        protected override Func<Queue<T>> GetInstantiator()
            => Instantiate;

        private static Queue<T> Instantiate()
            => new Queue<T>();
    }
}
