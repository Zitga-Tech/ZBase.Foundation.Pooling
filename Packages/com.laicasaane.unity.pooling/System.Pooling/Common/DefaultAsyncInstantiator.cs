using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public static class DefaultAsyncInstantiator<T> where T : class
    {
        private static readonly Type s_type = typeof(T);
        private static UniTaskFunc<T> s_default = Instantiate;

        private static async UniTask<T> Instantiate()
        {
            var result = (T)Activator.CreateInstance(s_type);
            return await UniTask.FromResult(result);
        }

        public static void Set(UniTaskFunc<T> instantiator)
            => s_default = instantiator ?? throw new ArgumentNullException(nameof(instantiator));

        public static UniTaskFunc<T> Get()
            => s_default ?? Instantiate;
    }
}
