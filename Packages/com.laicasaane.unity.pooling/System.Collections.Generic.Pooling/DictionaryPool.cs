using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public class DictionaryPool<TKey, TValue>
        : Pool<Dictionary<TKey, TValue>, DictionaryInstantiator<TKey, TValue>>
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

    public struct DictionaryInstantiator<TKey, TValue>
        : IInstantiable<Dictionary<TKey, TValue>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dictionary<TKey, TValue> Instantiate()
            => new Dictionary<TKey, TValue>();
    }
}
