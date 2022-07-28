using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public readonly struct DisposableContext<T> : IRentable<Disposable<T>>
    {
        internal readonly IPool<T> _pool;

        internal DisposableContext(IPool<T> pool)
        {
            _pool = pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable<T> Rent()
            => new Disposable<T>(_pool, _pool.Rent());
    }

    public static partial class PoolDisposableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DisposableContext<T> Disposable<T>(this IPool<T> pool)
            => new DisposableContext<T>(pool);
    }
}