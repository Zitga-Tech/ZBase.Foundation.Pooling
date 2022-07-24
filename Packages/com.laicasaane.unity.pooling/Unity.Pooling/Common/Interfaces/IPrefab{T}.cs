namespace Unity.Pooling
{
    public interface IPrefab<T, TSource> : IPrefab, IAsyncInstantiable<T>, IHasParent
    where T : class
    {
        TSource Source { get; set; }
    }
}
