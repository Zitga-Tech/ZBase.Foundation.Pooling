namespace System.Pooling
{
    public interface IRentable<T>
    {
        T Rent();
    }
}