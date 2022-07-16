namespace Unity.Pooling
{
    public interface ICountable
    {
        int Count();
    }

    public interface ICountable<T>
    {
        int Count(T item);
    }
}