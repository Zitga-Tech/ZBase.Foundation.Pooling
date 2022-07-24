using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;

namespace System.Pooling
{
    public class UniqueQueue<T> : IDisposable
    {
        private readonly HashSet<T> _unique;
        private readonly Queue<T> _queue;

        public UniqueQueue()
        {
            _unique = new HashSet<T>();
            _queue = new Queue<T>();
        }

        public UniqueQueue(HashSet<T> unique, Queue<T> queue)
        {
            _unique = unique ?? new HashSet<T>();
            _queue = queue ?? new Queue<T>();
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

        public void Enqueue(T item)
        {
            if (item is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.item);

            if (_unique.Contains(item))
                return;

            _unique.Add(item);
            _queue.Enqueue(item);
        }

        public T Dequeue()
        {
            var item = _queue.Dequeue();
            _unique.Remove(item);
            return item;
        }

        public bool TryDequeue(out T item)
        {
            if (_queue.TryDequeue(out item))
            {
                _unique.Remove(item);
                return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item)
            => _unique.Contains(item);
    }
}
