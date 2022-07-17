using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<T> : IPool<T>, INamedRentable<T>
        where T : UnityEngine.Object
    {
    }
}