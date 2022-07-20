namespace System.Pooling
{
    public interface IRentable<TKey, T> where T : class
    {
        T Rent(TKey key);
    }
}