namespace ZBase.Foundation.Pooling.UnityPools
{
    public interface IReleasable<T>
    {
        void Release(T instance);
    }
}