using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public static class DefaultAsyncInstantiator<T> where T : class
    {
        private static readonly Type s_type = typeof(T);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static async UniTask<T> Instantiate()
        {
            var result = (T)Activator.CreateInstance(s_type);
            return await UniTask.FromResult(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTaskFunc<T> Get()
            => Instantiate;
    }
}
