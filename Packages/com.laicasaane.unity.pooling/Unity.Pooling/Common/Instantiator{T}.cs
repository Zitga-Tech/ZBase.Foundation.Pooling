using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public abstract class Instantiator<T, S, TSource, TPrefab>
        : IInstantiator<T, S, TSource, TPrefab>
        where T : class
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
    {
        public abstract UniTask<T> Instantiate(TPrefab prefab, Transform defaultParent);
    }
}