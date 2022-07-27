using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public class HashSetPool<T> : Pool<HashSet<T>, HashSetInstantiator<T>>
    {
        public HashSetPool()
            : base(null)
        { }

        public HashSetPool(UniqueQueue<HashSet<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(HashSet<T> instance)
            => instance.Clear();
    }

    public struct HashSetInstantiator<T> : IInstantiable<HashSet<T>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HashSet<T> Instantiate()
            => new HashSet<T>();
    }
}
