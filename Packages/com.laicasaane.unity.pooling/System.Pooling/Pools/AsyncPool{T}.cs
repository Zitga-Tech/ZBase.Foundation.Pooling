namespace System.Pooling
{
    public class AsyncPool<T> : AsyncPoolBase<T>
        where T : class
    {
        public static readonly AsyncPool<T> Shared = new AsyncPool<T>();

        public AsyncPool()
            : base(null, null)
        { }

        public AsyncPool(UniqueQueue<T> queue)
            : base(queue, null)
        { }

        public AsyncPool(UniTaskFunc<T> instantiate)
            : base(null, instantiate)
        { }

        public AsyncPool(UniqueQueue<T> queue, UniTaskFunc<T> instantiate)
            : base(queue, instantiate)
        { }
    }
}
