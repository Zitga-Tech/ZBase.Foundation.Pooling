using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class GameObjectPrepoolerBase<TSource, TInstantiator, TPrefab, TPool>
        : UnityPrepooler<GameObject, TSource, TInstantiator, TPrefab, TPool>
        where TInstantiator : IAsyncInstantiable<TSource, GameObject>
        where TPrefab : IPrefab<GameObject, TSource, TInstantiator>
        where TPool : IReturnable<GameObject>
    {
    }
}