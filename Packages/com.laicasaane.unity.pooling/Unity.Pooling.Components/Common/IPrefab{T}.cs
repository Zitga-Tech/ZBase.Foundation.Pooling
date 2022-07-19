namespace Unity.Pooling.Components
{
    public interface IPrefab<T> : IPrefab
        where T : class
    {
        T Source { get; set;  }
    }
}
