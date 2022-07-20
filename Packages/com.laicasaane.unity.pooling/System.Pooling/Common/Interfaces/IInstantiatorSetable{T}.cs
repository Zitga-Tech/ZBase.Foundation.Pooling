namespace System.Pooling
{
    public interface IInstantiatorSetable<T>
    {
        void SetInstantiator(Func<T> instantiator);
    }
}
