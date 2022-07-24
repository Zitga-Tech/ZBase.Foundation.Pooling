namespace System.Pooling
{
    public interface IAsyncSetInstantiator<T>
    {
        void SetInstantiator(UniTaskFunc<T> instantiator);
    }
}
