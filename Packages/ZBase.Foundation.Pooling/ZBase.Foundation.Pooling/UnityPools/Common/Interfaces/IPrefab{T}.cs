namespace ZBase.Foundation.Pooling.UnityPools
{
    public interface IPrefab<T>
        : IPrefab, IAsyncInstantiable<T>, IReleasable<T>, IHasParent
    {
    }
}
