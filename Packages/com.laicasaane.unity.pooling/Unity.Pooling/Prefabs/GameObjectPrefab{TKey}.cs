using System;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPrefab<TKey>
        : UnityPrefab<TKey, GameObject, GameObject, GameObjectInstantiator>
    {
    }
}