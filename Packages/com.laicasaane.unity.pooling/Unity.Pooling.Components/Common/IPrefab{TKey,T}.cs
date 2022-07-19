namespace Unity.Pooling.Components
{
    public interface IPrefab<TKey, T> : IPrefab<T>
        where T : class
    {
        TKey Key { get; set; }
    }
}
