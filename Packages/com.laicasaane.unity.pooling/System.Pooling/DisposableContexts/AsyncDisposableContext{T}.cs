using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public readonly struct AsyncDisposableContext<T>
        where T : class
    {
        internal readonly IAsyncPool<T> _pool;

        internal AsyncDisposableContext(IAsyncPool<T> pool)
        {
            _pool = pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<Disposable<T>> RentAsync()
        {
            var result = await _pool.RentAsync();
            return new Disposable<T>(_pool, result);
        }
    }

    public static partial class AsyncPoolDisposableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncDisposableContext<T> Disposable<T>(this IAsyncPool<T> pool)
            where T : class
            => new AsyncDisposableContext<T>(pool);
    }
}