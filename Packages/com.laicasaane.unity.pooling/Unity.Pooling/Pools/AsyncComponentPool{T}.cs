using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class AsyncComponentPool<T> : AsyncUnityPoolBase<T>
        where T : UnityEngine.Component
    {
        public AsyncComponentPool()
            : base(null, null)
        { }

        public AsyncComponentPool(UniqueQueue<int, T> queue)
            : base(queue, null)
        { }

        public AsyncComponentPool(UniTaskFunc<T> instantiate)
            : base(null, instantiate)
        { }

        public AsyncComponentPool(UniqueQueue<int, T> queue, UniTaskFunc<T> instantiate)
            : base(queue, instantiate)
        { }

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
