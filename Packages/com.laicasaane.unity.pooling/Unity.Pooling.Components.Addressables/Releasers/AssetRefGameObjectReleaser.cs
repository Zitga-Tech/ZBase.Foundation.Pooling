using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    public class AssetRefGameObjectReleaser<TPrefab>
        : AssetRefReleaser<GameObject, AssetReferenceGameObject, TPrefab>
        where TPrefab : IPrefab<AssetReferenceGameObject>
    {
        public override void Release(TPrefab prefab, GameObject instance)
            => prefab.Source.ReleaseInstance(instance);
    }
}
