using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public class StackPool<T> : Pool<Stack<T>>
    {
        public StackPool()
            : base(Instantiate)
        { }

        public StackPool(UniqueQueue<Stack<T>> queue)
            : base(queue, Instantiate)
        { }

        public StackPool(Func<Stack<T>> instantiate)
            : base(null, instantiate ?? Instantiate)
        { }

        public StackPool(UniqueQueue<Stack<T>> queue, Func<Stack<T>> instantiate)
            : base(queue, instantiate ?? Instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Stack<T> instance)
            => instance.Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Stack<T> Instantiate()
            => new Stack<T>();
    }
}
