namespace Unity.Pooling
{
    public interface IPrefab<T, S, TSource> : IPrefab, IAsyncInstantiatable<T>
        where T : class
        where TSource : IAsyncInstantiatableSource<S, T>
    {
        TSource Source { get; set;  }
    }
}
