using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZBase.Foundation.Pooling.UnityPools
{
    [Serializable]
    public class GameObjectPrefab : UnityPrefab<GameObject, GameObject>
    {
        protected override async UniTask<GameObject> Instantiate(
              GameObject source
            , Transform parent
            , CancellationToken cancelToken
        )
        {
            GameObject instance;

            if (parent)
                instance = UnityEngine.Object.Instantiate(Source, parent, true);
            else
                instance = UnityEngine.Object.Instantiate(Source);

            return await UniTask.FromResult(instance);
        }

        public override void Release(GameObject instance)
        {
            if (instance)
                UnityEngine.Object.Destroy(instance);
        }
    }
}