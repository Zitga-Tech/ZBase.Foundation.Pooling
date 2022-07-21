using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPrepooler<TPool>
        : UnityPrepooler<GameObject, GameObject, GameObjectSource, GameObjectPrefab, TPool>
        where TPool : IReturnable<GameObject>
    {
    }
}