using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public interface IAsyncPrepooler<T, TSource, TInstantiator, TPrefab, TPool>
        where T : class
        where TInstantiator : IAsyncInstantiable<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
        where TPool : IReturnable<T>
    {
        UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent);
    }
}