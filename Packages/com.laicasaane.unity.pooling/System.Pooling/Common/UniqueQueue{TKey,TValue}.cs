using System.Runtime.CompilerServices;
using Collections.Pooled;
using Collections.Pooled.Generic;

namespace System.Pooling
{
    public class UniqueQueue<TKey, TValue> : IDisposable
    {
        private readonly HashSet<TKey> _unique;
        private readonly Queue<KVPair<TKey, TValue>> _queue;

        public UniqueQueue()
        {
            _unique = new HashSet<TKey>();
            _queue = new Queue<KVPair<TKey, TValue>>();
        }

        public UniqueQueue(HashSet<TKey> validate, Queue<KVPair<TKey, TValue>> queue)
        {
            _unique = validate ?? new HashSet<TKey>();
            _queue = queue ?? new Queue<KVPair<TKey, TValue>>();
        }

        public int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _unique.Count;
        }

        public void Dispose()
        {
            _unique.Dispose();
            _queue.Dispose();
        }

        public void Enqueue(in KVPair<TKey, TValue> item)
        {
            if (item.Key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

            if (item.Value is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.item);

            if (_unique.Contains(item.Key))
                return;

            _unique.Add(item.Key);
            _queue.Enqueue(item);
        }

        public KVPair<TKey, TValue> Dequeue()
        {
            var item = _queue.Dequeue();
            _unique.Remove(item.Key);
            return item;
        }

        public bool TryDequeue(out KVPair<TKey, TValue> item)
        {
            if (_queue.TryDequeue(out item))
            {
                _unique.Remove(item.Key);
                return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(TKey key)
            => _unique.Contains(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(in KVPair<TKey, TValue> item)
            => _unique.Contains(item.Key);
    }
}
