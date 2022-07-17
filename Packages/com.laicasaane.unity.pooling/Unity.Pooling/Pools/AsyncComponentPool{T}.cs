using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class AsyncComponentPool<T> : AsyncUnityPoolBase<T>
        where T : UnityEngine.Component
    {
        public static readonly AsyncComponentPool<T> Shared  = new AsyncComponentPool<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(T instance)
        {
            if (instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override UniTaskFunc<T> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UniTask<T> Instantiator()
        {
            var go = new GameObject(typeof(T).Name);
            var instance = go.AddComponent<T>();
            return UniTask.FromResult(instance);
        }
    }
}
