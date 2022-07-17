using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<T> : IUnityPool, IPool<T>, INamedRentable<T>
        where T : UnityEngine.Object
    {
    }
}