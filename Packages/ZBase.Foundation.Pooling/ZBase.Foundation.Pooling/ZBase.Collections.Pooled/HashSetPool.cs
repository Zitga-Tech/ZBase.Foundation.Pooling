using System.Runtime.CompilerServices;
using ZBase.Foundation.Pooling;

namespace ZBase.Collections.Pooled.Generic.Pooling
{
    public class HashSetPool<T>
        : Pool<HashSet<T>
        , DefaultConstructorInstantiator<HashSet<T>>>
    {
        public HashSetPool()
            : base()
        { }

        public HashSetPool(UniqueQueue<HashSet<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(HashSet<T> instance)
            => instance.Clear();
    }
}
