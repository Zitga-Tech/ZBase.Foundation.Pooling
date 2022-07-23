namespace Unity.Pooling
{
    public interface IPrefab<TKey, T, TSource, TInstantiator>
        : IPrefab<T, TSource, TInstantiator>
        where T : class
        where TInstantiator : IAsyncInstantiator<TSource, T>
    {
        TKey Key { get; set; }
    }
}
