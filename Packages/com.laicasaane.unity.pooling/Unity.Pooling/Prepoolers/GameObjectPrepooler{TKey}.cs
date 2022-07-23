using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPrepooler<TKey, TPool>
        : GameObjectPrepoolerBase<TKey, GameObject, GameObjectInstantiator, GameObjectPrefab<TKey>, TPool>
        where TPool : IReturnable<TKey, GameObject>
    {
    }
}