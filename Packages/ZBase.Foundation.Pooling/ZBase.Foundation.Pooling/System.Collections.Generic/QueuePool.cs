using System.Runtime.CompilerServices;
using ZBase.Foundation.Pooling;

namespace System.Collections.Generic.Pooling
{
    public class QueuePool<T>
        : Pool<Queue<T>
        , DefaultConstructorInstantiator<Queue<T>>>
    {
        public QueuePool()
            : base()
        { }

        public QueuePool(UniqueQueue<Queue<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Queue<T> instance)
            => instance.Clear();
    }
}
