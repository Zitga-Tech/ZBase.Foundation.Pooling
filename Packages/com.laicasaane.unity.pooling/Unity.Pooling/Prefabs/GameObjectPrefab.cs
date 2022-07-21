using System;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPrefab
        : UnityPrefab<GameObject, GameObject, GameObjectSource>
    {
    }
}