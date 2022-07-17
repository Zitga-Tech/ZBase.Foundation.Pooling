using System.Runtime.CompilerServices;

namespace System.Pooling
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

    partial class PoolDisposableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DisposableContext<TKey, T> Disposable<TKey, T>(this IPool<TKey, T> pool)
            where T : class
            => new DisposableContext<TKey, T>(pool);
    }
}