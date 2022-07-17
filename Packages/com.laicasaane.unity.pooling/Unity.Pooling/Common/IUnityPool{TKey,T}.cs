using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<TKey, T> : IPool<TKey, T>, INamedRentable<TKey, T>
        where T : UnityEngine.Object
    {
    }
}