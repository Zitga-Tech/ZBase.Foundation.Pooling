using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public readonly struct AsyncDisposableContext<T> : IAsyncRentable<Disposable<T>>
    {
        internal readonly IAsyncPool<T> _pool;

        internal AsyncDisposableContext(IAsyncPool<T> pool)
        {
            _pool = pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<Disposable<T>> Rent()
        {
            var result = await _pool.Rent();
            return new Disposable<T>(_pool, result);
        }
    }

    public static partial class AsyncPoolDisposableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncDisposableContext<T> DisposableContext<T>(this IAsyncPool<T> pool)
            => new AsyncDisposableContext<T>(pool);
    }
}