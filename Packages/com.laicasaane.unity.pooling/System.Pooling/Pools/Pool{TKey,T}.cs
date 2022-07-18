namespace System.Pooling
{
    public sealed class Pool<TKey, T> : PoolBase<TKey, T>
        where T : class
    {
        public static readonly Pool<TKey, T> Shared = new Pool<TKey, T>();

        public Pool()
            : base(null)
        { }

        public Pool(Func<T> instantiate)
            : base(instantiate)
        { }
    }
}
