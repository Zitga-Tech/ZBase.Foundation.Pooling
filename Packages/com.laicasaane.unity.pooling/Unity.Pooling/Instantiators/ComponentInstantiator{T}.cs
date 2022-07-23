using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentInstantiator<T> : UnityInstantiator<T, T>
        where T : UnityEngine.Component
    {
        public ComponentInstantiator() : base()
        { }

        public ComponentInstantiator(T source) : base(source)
        { }

        public override async UniTask<T> InstantiateAsync(Transform parent)
        {
            if (Source)
            {
                var instance = UnityEngine.Object.Instantiate(Source, parent);
                return await UniTask.FromResult(instance);
            }

            throw new NullReferenceException(nameof(Source));
        }
    }
}
