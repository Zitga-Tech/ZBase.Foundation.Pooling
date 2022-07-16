namespace Unity.Pooling
{
    public interface IReturnable<TKey, T> where T : class
    {
        void Return(TKey key, T instance);
    }
}
