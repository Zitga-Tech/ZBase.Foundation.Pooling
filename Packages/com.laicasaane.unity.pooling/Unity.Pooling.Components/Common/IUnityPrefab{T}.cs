namespace Unity.Pooling.Components
{
    public interface IUnityPrefab<T> : IUnityPrefab
        where T : UnityEngine.Object 
    {
        T Prefab { get; set;  }
    }
}
