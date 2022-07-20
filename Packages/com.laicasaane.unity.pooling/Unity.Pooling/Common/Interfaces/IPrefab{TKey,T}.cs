namespace Unity.Pooling
{
    public interface IPrefab<TKey, T, S, TSource>
        : IPrefab<T, S, TSource>
        where T : class
        where TSource : ILoadableSource<S, T>
    {
        TKey Key { get; set; }
    }
}
