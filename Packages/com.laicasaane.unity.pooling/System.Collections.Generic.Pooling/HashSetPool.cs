using System.Buffers;
using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public sealed class HashSetPool<T> : PoolBase<HashSet<T>>
    {
        public static readonly HashSetPool<T> Shared = new HashSetPool<T>();

        public HashSetPool()
            : base(Instantiate, ArrayPool<HashSet<T>>.Shared)
        { }

        public HashSetPool(Func<HashSet<T>> instantiate)
            : base(instantiate, ArrayPool<HashSet<T>>.Shared)
        { }

        public HashSetPool(ArrayPool<HashSet<T>> pool)
            : base(Instantiate, pool)
        { }

        public HashSetPool(Func<HashSet<T>> instantiate, ArrayPool<HashSet<T>> pool)
            : base(instantiate, pool)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override Func<HashSet<T>> GetInstantiator()
            => Instantiate;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(HashSet<T> instance)
            => instance.Clear();

        private static HashSet<T> Instantiate()
            => new HashSet<T>();
    }
}
