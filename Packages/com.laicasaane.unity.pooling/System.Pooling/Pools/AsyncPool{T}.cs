using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public class AsyncPool<T> : AsyncPool<T, AsyncInstantiator<T>>
        where T : class
    {
        public AsyncPool()
            : base(null)
        { }

        public AsyncPool(UniqueQueue<T> queue)
            : base(queue)
        { }
    }

    public struct AsyncInstantiator<T> : IAsyncInstantiable<T>
        where T : class
    {
        private static readonly Type s_type = typeof(T);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> Instantiate()
        {
            var result = (T)Activator.CreateInstance(s_type);
            return await UniTask.FromResult(result);
        }
    }
}
