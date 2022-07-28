using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class UnityPoolBehaviour<T, TSource, TPrefab, TPool, TPrepooler>
        : AsyncPoolBehaviour<T, TPool>, IPrepoolable
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T, TSource>
        where TPool : IUnityPool<T>, IHasPrefab<TPrefab>
        where TPrepooler : IPrepooler<T, TSource, TPrefab, TPool>, new()
    {
        [SerializeField]
        private bool _prepoolOnStart = false;

        public bool PrepoolOnStart
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolOnStart;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolOnStart = value;
        }

        private readonly TPrepooler _prepooler = new TPrepooler();

        protected void Awake()
        {
            if (Pool == null || Pool.Prefab == null)
                return;

            if (Pool.Prefab.Parent == false)
                Pool.Prefab.Parent = this.transform;

            OnAwake();
        }

        protected async UniTask Start()
        {
            if (_prepoolOnStart)
                await Prepool();

            await OnStart();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask Prepool()
            => await _prepooler.Prepool(Pool.Prefab, Pool, this.transform);

        protected virtual void OnAwake() { }

        protected async UniTask OnStart()
            => await UniTask.Delay(0);
    }
}
