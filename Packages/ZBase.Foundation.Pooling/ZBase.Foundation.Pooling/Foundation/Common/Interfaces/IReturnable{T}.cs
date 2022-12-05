namespace ZBase.Foundation.Pooling
{
    public interface IReturnable<T>
    {
        void Return(T instance);
    }
}
