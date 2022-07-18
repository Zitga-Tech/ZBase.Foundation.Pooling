using System;
using UnityEngine;

namespace Unity.Pooling.Components
{
    [Serializable]
    public sealed class GameObjectPrefab<TKey> : UnityPrefab<TKey, GameObject>
    {
    }
}