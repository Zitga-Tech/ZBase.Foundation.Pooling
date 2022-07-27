using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public class ListPool<T> : Pool<List<T>>
    {
        public ListPool()
            : base(Instantiate)
        { }

        public ListPool(UniqueQueue<List<T>> queue)
            : base(queue, Instantiate)
        { }

        public ListPool(Func<List<T>> instantiate)
            : base(null, instantiate ?? Instantiate)
        { }

        public ListPool(UniqueQueue<List<T>> queue, Func<List<T>> instantiate)
            : base(queue, instantiate ?? Instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(List<T> instance)
            => instance.Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static List<T> Instantiate()
            => new List<T>();
    }
}
