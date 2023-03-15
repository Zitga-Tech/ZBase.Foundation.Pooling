using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Collections.Pooled.Generic;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.AddressableAssets;
using Grid = Sample.Environment.Grid;

namespace Pooling.Sample
{
    public class AddressableGameObjectPoolSample2 : MonoBehaviour
    {
        private const string K_CHARACTER02_KEY = "Character_AddressPool_P02";

        private Grid _grid = new Grid(20, 15, true);
        private List<GameObject> _spawned = new List<GameObject>();
        private void Start()
        {
            var pool = SharedPool.Of<CustomAddressGameObjectPool>();
            pool.Prefab = new AddressGameObjectPrefab {
                Source = K_CHARACTER02_KEY,
                Parent = transform,
                PrepoolAmount = 100
            };
            pool.Prepool().Forget();
        }

        private async void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 150, 50), "Spawn"))
            {
                for (int i = 0; i < 100; i++)
                {
                    Spawn().Forget();
                }
                Debug.Log("Spawn 100 item from the CustomAddressGameObjectPool pool");
            }
            
            if (GUI.Button(new Rect(10, 70, 150, 50), "Spawn Disposable Item"))
            {
                await SpawnDisposableItems();
                Debug.Log("Item automatically returned to pool when context is disposed");
            }
            
            if (GUI.Button(new Rect(10, 130, 150, 50), "Return"))
            {
                Return();
                Debug.Log("Return all item to the pool");
            }
            
            if (GUI.Button(new Rect(10, 190, 150, 50), "Release All"))
            {
                ReleaseAll();
                Debug.Log("Release all item from the pool");
            }
        }
        
        private async UniTask Spawn()
        {
            var pool = SharedPool.Of<AddressGameObjectPool>();
            var go = await pool.Rent();
            go.transform.position = _grid.GetAvailableSlot().position;
            go.SetActive(true);
            _spawned.Add(go);
        }

        private void Return()
        {
            var pool = SharedPool.Of<AddressGameObjectPool>();
            foreach (var go in _spawned)
            {
                pool.Return(go);
                this._grid.FreeSlot(go.transform.position);
            }
        }
        
        private async UniTask SpawnDisposableItems()
        {
            var pool = SharedPool.Of<AddressGameObjectPool>();
            var context = pool.DisposableContext();
            using var go = await context.Rent();
            go.Instance.transform.position = _grid.GetAvailableSlot().position;
            go.Instance.SetActive(true);
            _spawned.Add(go.Instance);
            await UniTask.Delay(1500);
        }
        
        private void ReleaseAll()
        {
            var pool = SharedPool.Of<AddressGameObjectPool>();
            pool.ReleaseInstances(0);
            _spawned.Clear();
        }
        
        private void OnDisable()
        {
            ReleaseAll();
        }
    }
}