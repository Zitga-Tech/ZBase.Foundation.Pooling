using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPrefab : UnityPrefab<GameObject, GameObject>
    {
        protected override async UniTask<GameObject> Instantiate(GameObject source, Transform parent)
        {
            GameObject instance;

            if (parent)
                instance = UnityEngine.Object.Instantiate(Source, parent, true);
            else
                instance = UnityEngine.Object.Instantiate(Source);

            return await UniTask.FromResult(instance);
        }
    }
}