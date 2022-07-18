namespace System.Pooling
{
    public sealed class AsyncPool<T> : AsyncPoolBase<T>
        where T : class
    {
        public static readonly AsyncPool<T> Shared = new AsyncPool<T>();

        public AsyncPool()
            : base(null)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : base(instantiate)
        { }
    }
}
