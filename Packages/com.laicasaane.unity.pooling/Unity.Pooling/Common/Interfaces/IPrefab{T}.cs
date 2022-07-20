namespace Unity.Pooling
{
    public interface IPrefab<T, S, TSource> : IPrefab
        where T : class
        where TSource : ILoadableSource<S, T>
    {
        TSource Source { get; set;  }
    }
}
