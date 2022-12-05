namespace ZBase.Foundation.Pooling.UnityPools
{
    public interface IPrefab<T, TSource> : IPrefab<T>
    {
        TSource Source { get; set; }
    }
}
