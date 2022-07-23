using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IAsyncInstantiable<T>
    {
        UniTask<T> InstantiateAsync(Transform parent);
    }
}
