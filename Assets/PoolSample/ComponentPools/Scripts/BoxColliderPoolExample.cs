using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Collections.Pooled.Generic;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;
using Grid = Sample.Environment.Grid;

namespace Pooling.Sample
{
    public class BoxColliderPoolExample : MonoBehaviour
    {
        private readonly List<BoxCollider> _activeBoxColliders = new List<BoxCollider>();
        [SerializeField] private BoxCollider boxColliderPrefab;

        private readonly Grid _grid = new Grid(20, 15, false);

        private void Start()
        {
            //Get or create a pool
            var pool = SharedPool.Of<ComponentPool<BoxCollider, CubeBoxCollider>>();
            //Define the prefab to use for the pool
            pool.Prefab = new CubeBoxCollider {Source = this.boxColliderPrefab, Parent = this.transform};
            /*
            //You can also use a ComponentPrefab
            var pool2 = SharedPool.Of<ComponentPool<BoxCollider>>();
            pool2.Prefab = new ComponentPrefab<BoxCollider> {Source = this.boxColliderPrefab, Parent = this.transform, PrepoolAmount = 10};
            */
        }

        private async void OnGUI()
        {
            if (GUI.Button(new Rect(0, 100, 150, 50), "Rent 100"))
            {
                var pool = SharedPool.Of<ComponentPool<BoxCollider, CubeBoxCollider>>();
                for (int i = 0; i < 100; i++)
                {
                    var go = await pool.Rent();
                    var slot = this._grid.GetAvailableSlot();
                    go.transform.position = slot.position;
                    go.gameObject.SetActive(true);
                    this._activeBoxColliders.Add(go);
                }

                Debug.Log("Rent 100 item from the BoxCollider pool");
            }

            if (GUI.Button(new Rect(0, 200, 150, 50), "Rent Disposable Item"))
            {
                var pool = SharedPool.Of<ComponentPool<BoxCollider, CubeBoxCollider>>();
                var context = pool.DisposableContext();
                using var col = await context.Rent();
                col.Instance.gameObject.SetActive(true);
                var slot = _grid.GetAvailableSlot();
                col.Instance.transform.position = slot.position;
                this._activeBoxColliders.Add(col.Instance);
                await UniTask.Delay(1000);
                Debug.Log("Item automatically returned to pool when context is disposed");
            }

            //return 10
            if (GUI.Button(new Rect(0, 300, 150, 50), "Return 20"))
            {
                Return(20);

                Debug.Log("Return 20 item to the BoxCollider pool");
            }

            //release all
            if (GUI.Button(new Rect(0, 400, 150, 50), "Release All"))
            {
                ReleaseAll();
                Debug.Log("Release all item from the BoxCollider pool");
            }
        }

        private void Return(int count = 1)
        {
            var pool = SharedPool.Of<ComponentPool<BoxCollider, CubeBoxCollider>>();
            for (int i = 0; i < count; i++)
            {
                if (this._activeBoxColliders.Count > 0)
                {
                    var boxCollider = this._activeBoxColliders[0];
                    this._activeBoxColliders.RemoveAt(0);
                    if (boxCollider.gameObject.activeSelf)
                    {
                        pool.Return(boxCollider);
                        this._grid.FreeSlot(boxCollider.transform.position);
                    }
                }
            }
        }

        private void ReleaseAll()
        {
            var pool = SharedPool.Of<ComponentPool<BoxCollider, CubeBoxCollider>>();
            pool.ReleaseInstances(0);
            this._activeBoxColliders.Clear();
        }
    }
}