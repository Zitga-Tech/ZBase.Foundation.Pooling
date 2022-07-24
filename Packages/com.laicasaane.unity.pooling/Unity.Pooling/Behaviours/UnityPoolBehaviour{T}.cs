using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class UnityPoolBehaviour<T, TSource, TInstantiator, TPrefab, TPool, TPrepooler>
        : AsyncPoolBehaviourBase<T, TPool>, IAsyncPrepoolable
        where T : UnityEngine.Object
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
        where TPool : IUnityPool<T>, IHasPrefab<TPrefab>
        where TPrepooler : IAsyncPrepooler<T, TSource, TInstantiator, TPrefab, TPool>, new()
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

        protected virtual void Awake()
        {
            if (Pool == null || Pool.Prefab == null || Pool.Prefab.Instantiator == null)
                return;

            if (Pool.Prefab.Instantiator.Parent == false)
                Pool.Prefab.Instantiator.Parent = this.transform;
        }

        protected virtual async UniTask Start()
        {
            if (_prepoolOnStart)
                await PrepoolAsync();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask PrepoolAsync()
            => await _prepooler.PrepoolAsync(Pool.Prefab, Pool, this.transform);
    }
}
