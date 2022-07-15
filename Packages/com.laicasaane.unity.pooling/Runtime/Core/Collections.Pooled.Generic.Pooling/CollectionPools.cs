using System;
using System.Buffers;
using Unity.Pooling;

namespace Collections.Pooled.Generic.Pooling
{
    public sealed class ListPool<T> : PoolBase<List<T>>
    {
        public static readonly ListPool<T> Shared = new ListPool<T>();

        public ListPool()
            : base(Instantiator.Instantiate, ArrayPool<List<T>>.Shared)
        { }

        public ListPool(Func<List<T>> instantiate)
            : base(instantiate, ArrayPool<List<T>>.Shared)
        { }

        public ListPool(ArrayPool<List<T>> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public ListPool(Func<List<T>> instantiate, ArrayPool<List<T>> pool)
            : base(instantiate, pool)
        { }
    }

    public sealed class QueuePool<T> : PoolBase<Queue<T>>
    {
        public static readonly QueuePool<T> Shared = new QueuePool<T>();

        public QueuePool()
            : base(Instantiator.Instantiate, ArrayPool<Queue<T>>.Shared)
        { }

        public QueuePool(Func<Queue<T>> instantiate)
            : base(instantiate, ArrayPool<Queue<T>>.Shared)
        { }

        public QueuePool(ArrayPool<Queue<T>> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public QueuePool(Func<Queue<T>> instantiate, ArrayPool<Queue<T>> pool)
            : base(instantiate, pool)
        { }
    }

    public sealed class StackPool<T> : PoolBase<Stack<T>>
    {
        public static readonly StackPool<T> Shared = new StackPool<T>();

        public StackPool()
            : base(Instantiator.Instantiate, ArrayPool<Stack<T>>.Shared)
        { }

        public StackPool(Func<Stack<T>> instantiate)
            : base(instantiate, ArrayPool<Stack<T>>.Shared)
        { }

        public StackPool(ArrayPool<Stack<T>> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public StackPool(Func<Stack<T>> instantiate, ArrayPool<Stack<T>> pool)
            : base(instantiate, pool)
        { }
    }

    public sealed class HashSetPool<T> : PoolBase<HashSet<T>>
    {
        public static readonly HashSetPool<T> Shared = new HashSetPool<T>();

        public HashSetPool()
            : base(Instantiator.Instantiate, ArrayPool<HashSet<T>>.Shared)
        { }

        public HashSetPool(Func<HashSet<T>> instantiate)
            : base(instantiate, ArrayPool<HashSet<T>>.Shared)
        { }

        public HashSetPool(ArrayPool<HashSet<T>> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public HashSetPool(Func<HashSet<T>> instantiate, ArrayPool<HashSet<T>> pool)
            : base(instantiate, pool)
        { }
    }

    public sealed class DictionaryPool<TKey, TValue> : PoolBase<Dictionary<TKey, TValue>>
    {
        public static readonly DictionaryPool<TKey, TValue> Shared = new DictionaryPool<TKey, TValue>();

        public DictionaryPool()
            : base(Instantiator.Instantiate, ArrayPool<Dictionary<TKey, TValue>>.Shared)
        { }

        public DictionaryPool(Func<Dictionary<TKey, TValue>> instantiate)
            : base(instantiate, ArrayPool<Dictionary<TKey, TValue>>.Shared)
        { }

        public DictionaryPool(ArrayPool<Dictionary<TKey, TValue>> pool)
            : base(Instantiator.Instantiate, pool)
        { }

        public DictionaryPool(Func<Dictionary<TKey, TValue>> instantiate, ArrayPool<Dictionary<TKey, TValue>> pool)
            : base(instantiate, pool)
        { }
    }
}
