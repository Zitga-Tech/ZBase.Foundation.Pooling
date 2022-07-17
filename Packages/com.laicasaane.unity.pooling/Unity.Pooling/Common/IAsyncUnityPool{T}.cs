using System.Pooling;

namespace Unity.Pooling
{
    public interface IAsyncUnityPool<T> : IUnityPool, IAsyncPool<T>, IAsyncNamedRentable<T>
        where T : UnityEngine.Object
    {
    }
}
