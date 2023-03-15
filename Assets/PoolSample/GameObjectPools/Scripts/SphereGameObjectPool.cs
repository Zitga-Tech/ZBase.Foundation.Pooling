using System.Runtime.CompilerServices;
using UnityEngine;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;

namespace Pooling.Sample
{
    /// <summary>
    /// A concrete implementation of a GameObjectPool. In this example we are using a UnityPrepooler to prepool the GameObjects.
    /// </summary>
    public class SphereGameObjectPool : GameObjectPool
    {
        private readonly UnityPrepooler<GameObject, GameObjectPrefab, GameObjectPool> _prepooler;
        
        public SphereGameObjectPool() : base()
        {
            _prepooler = new UnityPrepooler<GameObject, GameObjectPrefab, GameObjectPool>();
        }
        
        public SphereGameObjectPool(GameObjectPrefab prefab) : base(prefab)
        {
            _prepooler = new UnityPrepooler<GameObject, GameObjectPrefab, GameObjectPool>();
        }
        
        public SphereGameObjectPool(UniqueQueue<int, GameObject> queue) : base(queue)
        {
            _prepooler = new UnityPrepooler<GameObject, GameObjectPrefab, GameObjectPool>();
        }
        
        public SphereGameObjectPool(UniqueQueue<int, GameObject> queue, GameObjectPrefab prefab) : base(queue, prefab)
        {
            _prepooler = new UnityPrepooler<GameObject, GameObjectPrefab, GameObjectPool>();
        }

        public void Prepool()
        {
            _prepooler.Prepool(Prefab, this, Prefab.Parent);
        }
    }
}