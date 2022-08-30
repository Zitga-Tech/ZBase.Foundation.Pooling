using System.Pooling;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
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