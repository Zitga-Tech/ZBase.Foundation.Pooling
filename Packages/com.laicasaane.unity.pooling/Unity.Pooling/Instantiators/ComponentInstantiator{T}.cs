using System;
using System.Runtime.CompilerServices;
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

        public ComponentInstantiator(Transform parent) : base(parent)
        { }

        public ComponentInstantiator(T source, Transform parent) : base(source, parent)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
