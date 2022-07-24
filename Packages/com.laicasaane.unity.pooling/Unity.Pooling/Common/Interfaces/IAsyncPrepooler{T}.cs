using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IAsyncPrepooler<T, TSource, TPrefab, TPool>
        where T : class
        where TPrefab : IPrefab<T, TSource>
        where TPool : IReturnable<T>
    {
        UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent);
    }

    public interface IAsyncPrepooler<T, TSource, TInstantiator, TPrefab, TPool>
        where T : class
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
        where TPool : IReturnable<T>
    {
        UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent);
    }
}