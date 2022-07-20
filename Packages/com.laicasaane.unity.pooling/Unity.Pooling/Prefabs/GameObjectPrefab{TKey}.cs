using System;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPrefab<TKey> : UnityObjectPrefab<TKey, GameObject, GameObjectSource>
    {
    }
}