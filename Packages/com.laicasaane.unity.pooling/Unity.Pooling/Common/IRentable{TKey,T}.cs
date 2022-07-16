namespace Unity.Pooling
{
    public interface IRentable<TKey, T> where T : class
    {
        T Rent(TKey key);
    }
}