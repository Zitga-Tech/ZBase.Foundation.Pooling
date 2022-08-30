using System.Threading;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    /// <summary>
    /// Create a new instance of <typeparamref name="T"/> via default constructor.
    /// </summary>
    public struct AsyncDefaultConstructorInstantiator<T> : IAsyncInstantiable<T>
        where T : class, new()
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> Instantiate()
            => await UniTask.FromResult(new T());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> Instantiate(CancellationToken cancelToken)
            => await UniTask.FromResult(new T());
    }
}
