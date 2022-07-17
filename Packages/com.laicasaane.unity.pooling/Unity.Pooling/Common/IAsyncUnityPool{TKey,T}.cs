using System.Pooling;

namespace Unity.Pooling
{
    public interface IAsyncUnityPool<TKey, T> : IUnityPool, IAsyncPool<TKey, T>, IAsyncNamedRentable<TKey, T>
        where T : UnityEngine.Object
    {
    }
}
