using System;
using System.Pooling;
using System.Runtime.CompilerServices;

namespace Collections.Pooled.Generic.Pooling
{
    public class DictionaryPool<TKey, TValue> : Pool<Dictionary<TKey, TValue>>
    {
        public DictionaryPool()
            : base(Instantiate)
        { }

        public DictionaryPool(Func<Dictionary<TKey, TValue>> instantiate)
            : base(instantiate ?? Instantiate)
        { }

        public DictionaryPool(UniqueQueue<Dictionary<TKey, TValue>> queue)
            : base(queue, Instantiate)
        { }

        public DictionaryPool(UniqueQueue<Dictionary<TKey, TValue>> queue, Func<Dictionary<TKey, TValue>> instantiate)
            : base(queue, instantiate ?? Instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Dictionary<TKey, TValue> instance)
            => instance.Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<TKey, TValue> Instantiate()
            => new Dictionary<TKey, TValue>();
    }
}
