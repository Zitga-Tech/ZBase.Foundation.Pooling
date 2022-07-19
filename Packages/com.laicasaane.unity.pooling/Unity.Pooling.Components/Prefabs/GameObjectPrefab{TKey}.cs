using System;
using UnityEngine;

namespace Unity.Pooling.Components
{
    [Serializable]
    public class GameObjectPrefab<TKey> : Prefab<TKey, GameObject>
    {
    }
}