namespace Unity.Pooling
{
    public interface IAsyncInstantiatableSource<S, T> : IAsyncInstantiatable<T>
        where T : class
    {
        S Source { get; set; }
    }
}
