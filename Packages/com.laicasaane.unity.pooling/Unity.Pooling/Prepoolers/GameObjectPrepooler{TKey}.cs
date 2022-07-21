using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPrepooler<TKey, TPool>
        : UnityPrepooler<TKey, GameObject, GameObject, GameObjectSource, GameObjectPrefab<TKey>, TPool>
        where TPool : IReturnable<TKey, GameObject>
    {
    }
}