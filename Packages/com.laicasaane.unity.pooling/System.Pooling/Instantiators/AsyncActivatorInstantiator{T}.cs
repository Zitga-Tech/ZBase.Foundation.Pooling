using System.Threading;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    /// <summary>
    /// Create a new instance of <typeparamref name="T"/> via
    /// <see cref="Activator"/>.<see cref="Activator.CreateInstance(Type)"/>.
    /// </summary>
    public struct AsyncActivatorInstantiator<T> : IAsyncInstantiable<T>
        where T : class
    {
        private static readonly Type s_type = typeof(T);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> Instantiate()
        {
            var result = (T)Activator.CreateInstance(s_type);
            return await UniTask.FromResult(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> Instantiate(CancellationToken cancelToken)
        {
            var result = (T)Activator.CreateInstance(s_type);
            return await UniTask.FromResult(result);
        }
    }
}
