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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override async UniTask<T> InstantiateAsync(T source, Transform parent)
        {
            var instance = UnityEngine.Object.Instantiate(Source, parent);
            return await UniTask.FromResult(instance);
        }
    }
}
