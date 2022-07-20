namespace System.Pooling
{
    public interface IRentable<T> where T : class
    {
        T Rent();
    }
}