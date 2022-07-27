using System.Pooling;
using System.Runtime.CompilerServices;

namespace Collections.Pooled.Generic.Pooling
{
    public class QueuePool<T> : Pool<Queue<T>, QueueInstantiator<T>>
    {
        public QueuePool()
            : base(null)
        { }

        public QueuePool(UniqueQueue<Queue<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Queue<T> instance)
            => instance.Clear();
    }

    public struct QueueInstantiator<T> : IInstantiable<Queue<T>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Queue<T> Instantiate()
            => new Queue<T>();
    }
}
