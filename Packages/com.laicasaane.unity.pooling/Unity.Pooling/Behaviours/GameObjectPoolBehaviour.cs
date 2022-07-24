﻿using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPoolBehaviour
        : UnityPoolBehaviour<GameObject, GameObject
            , GameObjectInstantiator
            , GameObjectPrefab
            , GameObjectPool
            , GameObjectPrepooler<GameObjectPool>
        >
    {
    }
}