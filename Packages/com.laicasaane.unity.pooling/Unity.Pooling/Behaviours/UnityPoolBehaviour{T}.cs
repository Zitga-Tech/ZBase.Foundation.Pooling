using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public abstract class UnityPoolBehaviour<T, TSource, TInstantiator, TPrefab, TPool, TPrepooler>
        : AsyncPoolBehaviourBase<T, TPool>, IPrepoolable
        where T : UnityEngine.Object
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
        where TPool : IUnityPool<T>, IHasPrefab<TPrefab>
        where TPrepooler : IAsyncPrepooler<T, TSource, TInstantiator, TPrefab, TPool>, new()
    {
        private readonly TPrepooler _prepooler = new TPrepooler();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask Prepool()
            => await _prepooler.PrepoolAsync(Pool.Prefab, Pool, this.transform);
    }
}
