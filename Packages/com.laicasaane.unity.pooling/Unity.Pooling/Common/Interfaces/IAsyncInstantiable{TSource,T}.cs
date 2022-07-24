namespace Unity.Pooling
{
    public interface IAsyncInstantiable<TSource, T> : IAsyncInstantiable<T>
        where T : class
    {
        TSource Source { get; set; }
    }
}
