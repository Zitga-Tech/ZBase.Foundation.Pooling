using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrefab<T> : UnityPrefab<T, T>
        where T : UnityEngine.Component
    {
        protected override async UniTask<T> InstantiateAsync(T source, Transform parent)
        {
            T instance;

            if (parent)
                instance = UnityEngine.Object.Instantiate(Source, parent);
            else
                instance = UnityEngine.Object.Instantiate(Source);

            return await UniTask.FromResult(instance);
        }
    }
}