using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public class StackPool<T> : Pool<Stack<T>, StackInstantiator<T>>
    {
        public StackPool()
            : base(null)
        { }

        public StackPool(UniqueQueue<Stack<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Stack<T> instance)
            => instance.Clear();
    }

    public struct StackInstantiator<T> : IInstantiable<Stack<T>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Stack<T> Instantiate()
            => new Stack<T>();
    }
}
