namespace System.Pooling
{
    public interface ISetInstantiator<T>
    {
        void SetInstantiator(Func<T> instantiator);
    }
}
