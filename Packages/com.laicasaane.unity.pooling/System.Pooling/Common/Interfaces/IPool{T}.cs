namespace System.Pooling
{
    public interface IPool<T> : IPool, IRentable<T>, IReturnable<T>, IReleaseInstances<T>, ICountable
    {
    }
}
