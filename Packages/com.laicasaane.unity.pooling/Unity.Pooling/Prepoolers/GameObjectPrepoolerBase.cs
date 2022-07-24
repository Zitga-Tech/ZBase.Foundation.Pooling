using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class GameObjectPrepoolerBase<TSource, TPrefab, TPool>
        : UnityPrepooler<GameObject, TSource, TPrefab, TPool>
        where TPrefab : IPrefab<GameObject, TSource>
        where TPool : IReturnable<GameObject>
    {
    }
}