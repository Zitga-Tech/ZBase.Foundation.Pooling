namespace System.Pooling
{
    public sealed class AsyncPool<TKey, T> : AsyncPoolBase<TKey, T>
        where T : class
    {
        public static readonly AsyncPool<TKey, T> Shared = new AsyncPool<TKey, T>();

        public AsyncPool()
            : base(null)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : base(instantiate)
        { }
    }
}
