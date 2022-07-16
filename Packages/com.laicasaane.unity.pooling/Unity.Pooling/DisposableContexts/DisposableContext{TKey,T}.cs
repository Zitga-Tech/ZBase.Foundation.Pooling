using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public readonly struct DisposableContext<TKey, T>
        where T : class
    {
        internal readonly IPool<TKey, T> _pool;

        internal DisposableContext(IPool<TKey, T> pool)
        {
            _pool = pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable<TKey, T> Rent(TKey key)
            => new Disposable<TKey, T>(_pool, key, _pool.Rent(key));
    }
}