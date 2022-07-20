namespace System.Pooling
{
    public interface IAsyncInstantiatorSetable<T>
    {
        void SetInstantiator(UniTaskFunc<T> instantiator);
    }
}
