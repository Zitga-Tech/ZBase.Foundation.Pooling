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
            if (source == false)
            {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
            }

            GameObject instance;

            if (parent)
                instance = UnityEngine.Object.Instantiate(source, parent, true);
            else
                instance = UnityEngine.Object.Instantiate(source);

            return await UniTask.FromResult(instance);
        }

        public override void Release(GameObject instance)
        {
            if (instance)
                UnityEngine.Object.Destroy(instance);
        }
    }
}