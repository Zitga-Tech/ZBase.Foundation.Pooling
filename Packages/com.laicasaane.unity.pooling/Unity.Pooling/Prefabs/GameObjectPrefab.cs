using System;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public sealed class GameObjectPrefab : UnityObjectPrefab<GameObject, GameObjectSource>
    {
    }
}