namespace Unity.Pooling
{
    public interface IPrefab<T, TSource> : IPrefab, IAsyncInstantiable<T>
    where T : class
    {
    }

    public interface IPrefab<T, TSource, TInstantiator> : IPrefab<T, TSource>, IAsyncInstantiable<T>
        where T : class
        where TInstantiator : IAsyncInstantiator<TSource, T>
    {
        TInstantiator Instantiator { get; set;  }
    }
}
