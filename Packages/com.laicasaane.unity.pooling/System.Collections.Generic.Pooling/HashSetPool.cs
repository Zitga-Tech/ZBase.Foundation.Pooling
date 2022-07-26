using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public sealed class HashSetPool<T> : PoolBase<HashSet<T>>
    {
        public static readonly HashSetPool<T> Shared = new HashSetPool<T>();

        public HashSetPool()
            : base(Instantiate)
        { }

        public HashSetPool(UniqueQueue<HashSet<T>> queue)
            : base(queue, Instantiate)
        { }

        public HashSetPool(Func<HashSet<T>> instantiate)
            : base(null, instantiate ?? Instantiate)
        { }

        public HashSetPool(UniqueQueue<HashSet<T>> queue, Func<HashSet<T>> instantiate)
            : base(queue, instantiate ?? Instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(HashSet<T> instance)
            => instance.Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static HashSet<T> Instantiate()
            => new HashSet<T>();
    }
}
