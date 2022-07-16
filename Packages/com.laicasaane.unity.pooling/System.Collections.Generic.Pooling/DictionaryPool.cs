using System.Buffers;
using System.Pooling;

namespace System.Collections.Generic.Pooling
{
    public sealed class DictionaryPool<TKey, TValue> : PoolBase<Dictionary<TKey, TValue>>
    {
        public static readonly DictionaryPool<TKey, TValue> Shared = new DictionaryPool<TKey, TValue>();

        public DictionaryPool()
            : base(Instantiate, ArrayPool<Dictionary<TKey, TValue>>.Shared)
        { }

        public DictionaryPool(Func<Dictionary<TKey, TValue>> instantiate)
            : base(instantiate, ArrayPool<Dictionary<TKey, TValue>>.Shared)
        { }

        public DictionaryPool(ArrayPool<Dictionary<TKey, TValue>> pool)
            : base(Instantiate, pool)
        { }

        public DictionaryPool(Func<Dictionary<TKey, TValue>> instantiate, ArrayPool<Dictionary<TKey, TValue>> pool)
            : base(instantiate, pool)
        { }

        protected override Func<Dictionary<TKey, TValue>> GetInstantiator()
            => Instantiate;

        private static Dictionary<TKey, TValue> Instantiate()
            => new Dictionary<TKey, TValue>();
    }
}
