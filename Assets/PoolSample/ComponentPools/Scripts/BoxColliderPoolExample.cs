using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;

namespace Pooling.Sample
{
    public class BoxColliderPoolExample : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider[] boxColliders;
        [SerializeField]
        private BoxCollider boxColliderPrefab;
        private async void Start()
        {
            var pool = SharedPool.Of<ComponentPool<BoxCollider, CubeBoxCollider>>();
            //Define the prefab to use for the pool
            pool.Prefab = new CubeBoxCollider {Source = this.boxColliderPrefab, Parent = this.transform, PrepoolAmount = 10};

            //Rent an instance from the pool
            var instance = await pool.Rent();
            instance.size = new Vector3(1, 1, 1);
            instance.center = new Vector3(0, 0, 0);
            instance.gameObject.name = "BoxCollider 1";
            Debug.Log("Rent an instance from the BoxCollider pool with id: " + instance.GetInstanceID());

            await UniTask.Delay(1000);
            //create a disposable context, this will return the instance to the pool when the context is disposed
            var context = pool.DisposableContext();
            using var col = await context.Rent();
            col.Instance.size = new Vector3(1, 1, 1);
            col.Instance.center = new Vector3(0, 0, 0);
            col.Instance.gameObject.name = "BoxCollider 2";
            Debug.Log("Rent an instance from the BoxCollider pool with id: " + col.Instance.GetInstanceID());
            
            pool.Return(instance);
            
            var pool2 = SharedPool.Of<ComponentPool<BoxCollider>>();
            pool2.Prefab = new ComponentPrefab<BoxCollider> {Source = this.boxColliderPrefab, Parent = this.transform, PrepoolAmount = 10};
        }

        private async void OnGUI()
        {
            if (GUILayout.Button("Rent"))
            {
                var pool = SharedPool.Of<ComponentPool<BoxCollider, CubeBoxCollider>>();
                var context = pool.DisposableContext();
                using var col = await context.Rent();
                Debug.Log("Rent an instance from the BoxCollider pool with id: " + col.Instance.GetInstanceID());
            }

        }
    }
}