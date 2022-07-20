using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.AddressableAssets
{
    public sealed class AssetRefGameObjectPoolComponent
        : AssetRefPoolComponentBase<GameObject, AssetReferenceGameObject, AssetRefGameObjectPrefab, AsyncGameObjectPool>
    {
        private readonly AssetRefGameObjectPrepooler<AssetRefGameObjectPrefab, AsyncGameObjectPool> _pooler = new();
        private readonly AssetRefGameObjectInstantiator<AssetRefGameObjectPrefab> _instantiator = new();
        private readonly AssetRefGameObjectReleaser<AssetRefGameObjectPrefab> _releaser = new();

        public override async UniTask Prepool()
            => await _pooler.Prepool(Prefab, Pool, this.transform);

        protected override async UniTask<GameObject> InstantiateAsync()
            => await _instantiator.InstantiateAsync(Prefab, this.transform);

        protected override void ReleaseInstance(GameObject instance)
            => _releaser.Release(Prefab, instance);
    }
}
