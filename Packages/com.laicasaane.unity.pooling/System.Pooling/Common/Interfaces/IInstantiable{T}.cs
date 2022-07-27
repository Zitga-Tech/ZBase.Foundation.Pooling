namespace System.Pooling
{
    public interface IInstantiable<T>
    {
        T Instantiate();
    }
}
