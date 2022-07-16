using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
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
}