namespace System.Pooling
{
    public sealed class Pool<T> : PoolBase<T>
        where T : class
    {
        public static readonly Pool<T> Shared = new Pool<T>();

        public Pool()
            : base(null)
        { }

        public Pool(Func<T> instantiate)
            : base(instantiate)
        { }
    }
}
