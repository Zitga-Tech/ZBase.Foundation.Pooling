using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IInstantiator<T, S, TSource, TPrefab>
        where T : class
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
    {
        UniTask<T> Instantiate(TPrefab prefab, Transform defaultParent);
    }
}