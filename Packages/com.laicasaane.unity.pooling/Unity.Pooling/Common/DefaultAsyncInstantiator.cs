using System;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    internal static class DefaultAsyncInstantiator<T>
    {
        private static readonly Type s_type = typeof(T);

        public static async UniTask<T> Instantiate()
        {
            var result = (T)Activator.CreateInstance(s_type);
            return await UniTask.FromResult(result);
        }
    }
}
