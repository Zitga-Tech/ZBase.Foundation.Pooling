using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    public class AssetRefGameObjectPoolComponent<TKey>
        : AssetRefPoolComponentBase<TKey, GameObject, AssetReferenceGameObject, AssetRefGameObjectPrefab<TKey>, AsyncGameObjectPool<TKey>>
    {
        private readonly AssetRefGameObjectPrepooler<TKey,AssetRefGameObjectPrefab<TKey>, AsyncGameObjectPool<TKey>> _pooler = new();
        private readonly AssetRefGameObjectInstantiator<AssetRefGameObjectPrefab<TKey>> _instantiator = new();
        private readonly AssetRefGameObjectReleaser<AssetRefGameObjectPrefab<TKey>> _releaser = new();

        public override async UniTask Prepool()
            => await _pooler.Prepool(Prefab, Pool, this.transform);

        protected override async UniTask<GameObject> InstantiateAsync()
            => await _instantiator.InstantiateAsync(Prefab, this.transform);

        protected override void ReleaseInstance(GameObject instance)
            => _releaser.Release(Prefab, instance);
    }
}
