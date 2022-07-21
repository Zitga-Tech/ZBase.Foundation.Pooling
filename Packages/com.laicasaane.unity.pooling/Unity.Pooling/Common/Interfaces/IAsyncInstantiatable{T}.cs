using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IAsyncInstantiatable<T>
    {
        UniTask<T> InstantiateAsync(Transform parent);
    }
}
