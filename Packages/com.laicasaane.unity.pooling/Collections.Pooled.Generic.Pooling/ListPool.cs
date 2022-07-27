using System.Pooling;
using System.Runtime.CompilerServices;

namespace Collections.Pooled.Generic.Pooling
{
    public class ListPool<T> : Pool<List<T>, ListInstantiator<T>>
    {
        public ListPool()
            : base(null)
        { }

        public ListPool(UniqueQueue<List<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(List<T> instance)
            => instance.Clear();
    }

    public struct ListInstantiator<T> : IInstantiable<List<T>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public List<T> Instantiate()
            => new List<T>();
    }
}
