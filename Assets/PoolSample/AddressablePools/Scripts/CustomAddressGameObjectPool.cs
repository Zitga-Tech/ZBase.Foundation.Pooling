using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.AddressableAssets;
using ZBase.Foundation.Pooling.UnityPools;

namespace Pooling.Sample
{
    public class CustomAddressGameObjectPool : AddressGameObjectPool
    {
        private readonly UnityPrepooler<GameObject, AddressGameObjectPrefab, AddressGameObjectPool> _prepooler;

        public CustomAddressGameObjectPool()
            : base()
        {
            _prepooler = new UnityPrepooler<GameObject, AddressGameObjectPrefab, AddressGameObjectPool>();
        }

        public CustomAddressGameObjectPool(AddressGameObjectPrefab prefab)
            : base(prefab)
        {
            _prepooler = new UnityPrepooler<GameObject, AddressGameObjectPrefab, AddressGameObjectPool>();
        }

        public CustomAddressGameObjectPool(UniqueQueue<int, GameObject> queue)
            : base(queue)
        {
            _prepooler = new UnityPrepooler<GameObject, AddressGameObjectPrefab, AddressGameObjectPool>();
        }

        public CustomAddressGameObjectPool(UniqueQueue<int, GameObject> queue, AddressGameObjectPrefab prefab)
            : base(queue, prefab)
        {
            _prepooler = new UnityPrepooler<GameObject, AddressGameObjectPrefab, AddressGameObjectPool>();
        }

        public async UniTask Prepool()
        {
            await _prepooler.Prepool(Prefab, this, Prefab.Parent);
        }
    }
}