using Unity.Pooling;

namespace System.Collections.Generic.Pooling
{
    public sealed class ListPool<T> : PoolBase<List<T>>
    {
        public static readonly ListPool<T> Shared = new ListPool<T>();
    }

    public sealed class QueuePool<T> : PoolBase<Queue<T>>
    {
        public static readonly QueuePool<T> Shared = new QueuePool<T>();
    }

    public sealed class StackPool<T> : PoolBase<Stack<T>>
    {
        public static readonly StackPool<T> Shared = new StackPool<T>();
    }

    public sealed class HashSetPool<T> : PoolBase<HashSet<T>>
    {
        public static readonly HashSetPool<T> Shared = new HashSetPool<T>();
    }

    public sealed class DictionaryPool<TKey, TValue> : PoolBase<Dictionary<TKey, TValue>>
    {
        public static readonly DictionaryPool<TKey, TValue> Shared = new DictionaryPool<TKey, TValue>();
    }
}
