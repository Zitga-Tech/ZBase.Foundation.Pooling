using System.Pooling;
using System.Runtime.CompilerServices;

namespace Collections.Pooled.Generic.Pooling
{
    public class ArrayDictionaryPool<TKey, TValue>
        : Pool<ArrayDictionary<TKey, TValue>
        , DefaultConstructorInstantiator<ArrayDictionary<TKey, TValue>>>
    {
        public ArrayDictionaryPool()
            : base()
        { }

        public ArrayDictionaryPool(UniqueQueue<ArrayDictionary<TKey, TValue>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(ArrayDictionary<TKey, TValue> instance)
            => instance.Clear();
    }
}
