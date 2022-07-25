namespace System.Pooling
{
    public class Pool<T> : PoolBase<T>
        where T : class
    {
        public static readonly Pool<T> Shared = new Pool<T>();

        public Pool()
            : base(null, null)
        { }

        public Pool(UniqueQueue<T> queue)
            : base(queue, null)
        { }

        public Pool(Func<T> instantiate)
            : base(null, instantiate)
        { }

        public Pool(UniqueQueue<T> queue, Func<T> instantiate)
            : base(queue, instantiate)
        { }
    }
}
