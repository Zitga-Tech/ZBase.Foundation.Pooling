using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPrepooler<TPool>
        : UnityPrepooler<GameObject, GameObject, GameObjectInstantiator, GameObjectPrefab, TPool>
        where TPool : IReturnable<GameObject>
    {
    }
}