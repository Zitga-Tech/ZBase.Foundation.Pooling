namespace ZBase.Foundation.Pooling
{
    public class Pool<T> : Pool<T, ActivatorInstantiator<T>>
        where T : class
    {
        public Pool()
            : base()
        { }

        public Pool(UniqueQueue<T> queue)
            : base(queue)
        { }
    }
}
