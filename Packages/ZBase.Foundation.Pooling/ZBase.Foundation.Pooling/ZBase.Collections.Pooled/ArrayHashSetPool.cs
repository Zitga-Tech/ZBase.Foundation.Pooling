using System.Runtime.CompilerServices;
using ZBase.Foundation.Pooling;

namespace ZBase.Collections.Pooled.Generic.Pooling
{
    public class ArrayHashSetPool<T>
        : Pool<ArrayHashSet<T>
        , DefaultConstructorInstantiator<ArrayHashSet<T>>>
    {
        public ArrayHashSetPool()
            : base()
        { }

        public ArrayHashSetPool(UniqueQueue<ArrayHashSet<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(ArrayHashSet<T> instance)
            => instance.Clear();
    }
}
