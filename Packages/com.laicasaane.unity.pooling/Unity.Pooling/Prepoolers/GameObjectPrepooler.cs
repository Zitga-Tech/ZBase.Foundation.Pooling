using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPrepooler<TPool>
        : GameObjectPrepoolerBase<GameObject, GameObjectInstantiator, GameObjectPrefab, TPool>
        where TPool : IReturnable<GameObject>
    {
    }
}