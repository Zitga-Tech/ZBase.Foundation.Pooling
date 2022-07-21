namespace Unity.Pooling
{
    public interface IPrefab<TKey, T, S, TSource>
        : IPrefab<T, S, TSource>
        where T : class
        where TSource : IAsyncInstantiatableSource<S, T>
    {
        TKey Key { get; set; }
    }
}
