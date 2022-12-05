using System.Runtime.CompilerServices;

namespace ZBase.Foundation.Pooling
{
    public class UniqueQueue<T> : UniqueQueue<T, T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryEnqueue(T item)
            => TryEnqueue(item, item);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryDequeue(out T item)
            => TryDequeue(out var _, out item);
    }
}
