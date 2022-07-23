using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class GameObjectPrepoolerBase<TKey, TSource, TInstantiator, TPrefab, TPool>
        : UnityPrepooler<TKey, GameObject, TSource, TInstantiator, TPrefab, TPool>
        where TInstantiator : IAsyncInstantiator<TSource, GameObject>
        where TPrefab : IPrefab<TKey, GameObject, TSource, TInstantiator>
        where TPool : IReturnable<TKey, GameObject>
    {
    }
}