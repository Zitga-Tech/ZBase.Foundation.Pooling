namespace ZBase.Foundation.Pooling
{
    public class AsyncPool<T> : AsyncPool<T, AsyncActivatorInstantiator<T>>
        where T : class
    {
        public AsyncPool()
            : base()
        { }

        public AsyncPool(UniqueQueue<T> queue)
            : base(queue)
        { }
    }
}
