namespace Unity.Pooling
{
    public interface IPrefab<T, TSource, TInstantiator> : IPrefab, IAsyncInstantiable<T>
        where T : class
        where TInstantiator : IAsyncInstantiator<TSource, T>
    {
        TInstantiator Instantiator { get; set;  }
    }
}
