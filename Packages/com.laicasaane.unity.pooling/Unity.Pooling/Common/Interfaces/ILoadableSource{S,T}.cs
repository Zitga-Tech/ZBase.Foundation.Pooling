namespace Unity.Pooling
{
    public interface ILoadableSource<S, T> : ILoadable<T>
        where T : class
    {
        S Source { get; set; }
    }
}
