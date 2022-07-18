using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class AsyncComponentPool<TKey, T> : AsyncUnityPoolBase<TKey, T>
        where T : UnityEngine.Component
    {
        public static readonly AsyncComponentPool<TKey, T> Shared  = new AsyncComponentPool<TKey, T>();

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
            var go = new GameObject(NameOf<T>.Value);
            var instance = go.AddComponent<T>();
            return UniTask.FromResult(instance);
        }
    }
}
