using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IPrepooler<T, TSource, TPrefab, TPool>
        where TPrefab : IPrefab<T, TSource>
        where TPool : IReturnable<T>
    {
        UniTask Prepool(TPrefab prefab, TPool pool, Transform defaultParent);
    }
}