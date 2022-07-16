using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public readonly struct DisposableContext<T>
        where T : class
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
}