namespace ZBase.Foundation.Pooling
{
    public interface IRentable<T>
    {
        T Rent();
    }
}