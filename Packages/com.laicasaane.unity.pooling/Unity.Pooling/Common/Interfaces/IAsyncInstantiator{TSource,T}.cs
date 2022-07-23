namespace Unity.Pooling
{
    public interface IAsyncInstantiator<TSource, T> : IAsyncInstantiable<T>
        where T : class
    {
        TSource Source { get; set; }
    }
}
