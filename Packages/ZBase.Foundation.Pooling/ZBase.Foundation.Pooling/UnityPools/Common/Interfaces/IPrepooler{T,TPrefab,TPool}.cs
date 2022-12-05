using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZBase.Foundation.Pooling.UnityPools
{
    public interface IPrepooler<T, TPrefab, TPool>
        where TPrefab : IPrefab<T>
        where TPool : IReturnable<T>
    {
        UniTask Prepool(
              TPrefab prefab
            , TPool pool
            , Transform defaultParent
            , CancellationToken cancelToken = default
        );
    }
}