using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IAsyncPrepooler<T, S, TSource, TPrefab, TPool>
        where T : class
        where TSource : IAsyncInstantiatableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
        where TPool : IReturnable<T>
    {
        UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent);
    }
}