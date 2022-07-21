using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectSource : UnitySource<GameObject, GameObject>
    {
        public GameObjectSource() : base()
        { }

        public GameObjectSource(GameObject source) : base(source)
        { }

        public override async UniTask<GameObject> InstantiateAsync(Transform parent)
        {
            if (Source)
            {
                var instance = UnityEngine.Object.Instantiate(Source, parent);
                return await UniTask.FromResult(instance);
            }

            throw new NullReferenceException(nameof(Source));
        }
    }
}
