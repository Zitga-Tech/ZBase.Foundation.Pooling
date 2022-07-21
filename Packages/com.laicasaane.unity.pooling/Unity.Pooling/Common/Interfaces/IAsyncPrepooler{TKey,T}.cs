using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IAsyncPrepooler<TKey, T, S, TSource, TPrefab, TPool>
        where T : class
        where TSource : IAsyncInstantiatableSource<S, T>
        where TPrefab : IPrefab<TKey, T, S, TSource>
        where TPool : IReturnable<TKey, T>
    {
        UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent);
    }
}