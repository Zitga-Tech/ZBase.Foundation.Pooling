using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IAsyncPrepooler<T, TSource, TPrefab, TPool>
        where TPrefab : IPrefab<T, TSource>
        where TPool : IReturnable<T>
    {
        UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent);
    }
}