namespace System.Pooling
{
    public interface IReturnable<T>
    {
        void Return(T instance);
    }
}
