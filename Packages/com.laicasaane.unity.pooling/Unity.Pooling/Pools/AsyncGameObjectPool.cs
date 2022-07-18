using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public sealed class AsyncGameObjectPool : AsyncUnityPoolBase<GameObject>
    {
        public static readonly AsyncGameObjectPool Shared  = new AsyncGameObjectPool();

        public AsyncGameObjectPool()
            : base(null, null)
        { }

        public AsyncGameObjectPool(UniqueQueue<int, GameObject> queue)
            : base(queue, null)
        { }

        public AsyncGameObjectPool(UniTaskFunc<GameObject> instantiate)
            : base(null, instantiate)
        { }

        public AsyncGameObjectPool(UniqueQueue<int, GameObject> queue, UniTaskFunc<GameObject> instantiate)
            : base(queue, instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override UniTaskFunc<GameObject> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UniTask<GameObject> Instantiator()
        {
            var go = new GameObject();
            return UniTask.FromResult(go);
        }
    }
}
