namespace Unity.Pooling
{
    public interface IReleasable<T>
    {
        void Release(T instance);
    }
}