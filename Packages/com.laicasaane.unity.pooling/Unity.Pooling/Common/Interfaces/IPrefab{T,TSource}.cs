namespace Unity.Pooling
{
    public interface IPrefab<T, TSource> : IPrefab<T>
    {
        TSource Source { get; set; }
    }
}
