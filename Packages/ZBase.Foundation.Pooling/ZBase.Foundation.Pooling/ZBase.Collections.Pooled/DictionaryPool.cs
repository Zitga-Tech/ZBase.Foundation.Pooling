using System.Runtime.CompilerServices;
using ZBase.Foundation.Pooling;

namespace ZBase.Collections.Pooled.Generic.Pooling
{
    public class DictionaryPool<TKey, TValue>
        : Pool<Dictionary<TKey, TValue>
        , DefaultConstructorInstantiator<Dictionary<TKey, TValue>>>
    {
        public DictionaryPool()
            : base()
        { }

        public DictionaryPool(UniqueQueue<Dictionary<TKey, TValue>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Dictionary<TKey, TValue> instance)
            => instance.Clear();
    }
}
