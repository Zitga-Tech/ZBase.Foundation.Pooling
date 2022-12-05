using System.Runtime.CompilerServices;
using ZBase.Foundation.Pooling;

namespace ZBase.Collections.Pooled.Generic.Pooling
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
