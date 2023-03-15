using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Collections.Pooled.Generic;
using ZBase.Foundation.Pooling.AddressableAssets;

namespace Pooling.Sample
{
    /// <summary>
    /// This is a sample to use the AssetRefGameObjectPoolBehaviour pool.
    /// Steps to use:
    /// 1. Add this component to a GameObject in the scene.
    /// 2. Create a pool behaviour by adding AssetRefGameObjectPoolBehaviour to a GameObject in the scene.
    /// 3. Set up the Prefab of the pool behaviour.
    ///     3.1 Source: The AssetReferenceGameObject of the prefab.
    ///     3.2 Parent: The parent of the prefab.
    ///     3.3 Prepool amount: The number of prefabs to prepool.
    ///     3.4 Prepool on start: Whether to prepool on start.
    /// 4. Reference the pool behaviour in your code.
    /// 5. Rent and return objects
    /// Remember to use AssetRefGameObjectPoolBehaviour.ReleaseInstances to release all instances from memory.
    /// </summary>
    public class AddressablePoolBehaviourSample2 : MonoBehaviour
    {
        [SerializeField] private AssetRefGameObjectPoolBehaviour pool;

        private List<GameObject> _spawned = new List<GameObject>();
        private List<Vector3> _slots = new List<Vector3>();

        private void Start()
        {
            for (int x = -25; x < 25; x++)
            {
                if(x % 2 == 0)
                    continue;
                for (int z = -15; z < 15; z++)
                {
                    if(z % 2 == 0)
                        continue;
                    this._slots.Add(new Vector3(x, 0, z));
                }
            }
        }

        private async void OnGUI()
        {
            if(GUI.Button(new Rect(10, 10, 150, 50), "Spawn 100"))
            {
                for (int i = 0; i < 100; i++)
                {
                    await Spawn();
                }
            }
            
            if(GUI.Button(new Rect(10, 70, 150, 50), "Despawn 10"))
            {
                int count = 10;
                Despawn(ref count);
            }
            
            if(GUI.Button(new Rect(10, 130, 150, 50), "Release Keep 10"))
            {
                Release();
            }
        }

        private async UniTask Spawn()
        {
            var go = await this.pool.Rent();
            go.transform.position = this._slots[this._spawned.Count];
            go.SetActive(true);
            this._spawned.Add(go);
        }
        
        private void Despawn(ref int count)
        {
            //despawn count last spawned active
            for (int i = this._spawned.Count - 1; i >= 0; i--)
            {
                if(this._spawned[i].activeSelf)
                {
                    this.pool.Return(this._spawned[i]);
                    count--;
                    if(count == 0)
                        break;
                }
            }
        }
        
        private void Release()
        {
            this.pool.ReleaseInstances(10);
        }

        private void OnDestroy()
        {
            //release all instances when this object is destroyed
            this.pool.ReleaseInstances(0);
        }
    }
}