namespace Unity.Pooling
{
    public interface IHasPrefab<T>
        where T : IPrefab
    {
        T Prefab { get; set; }
    }
}
