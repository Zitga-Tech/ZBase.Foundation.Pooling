using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Collections.Pooled.Generic;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;

namespace Pooling.Sample
{
    public class GameObjectPoolSample : MonoBehaviour
    {
        public Transform poolParent1;
        public Transform poolParent2;
        public GameObject prefab1;
        public GameObject prefab2;
        //you can access the spawned objects in your own list
        public List<GameObject> myGameObjects = new List<GameObject>();
        
        //Manage lifetime of the pool yourself (in this case, the pool4 will not be registered in the SharedPool)
        public GameObjectPool pool4;
        public List<GameObject> pool4Objects = new List<GameObject>();
        private void Start()
        {
            //GameObjectPool do not have implementation of Prepool
            var pool1 = new GameObjectPool();
            pool1.Prefab = new GameObjectPrefab() {Parent = poolParent1, Source = this.prefab1};
            pool1.Rent().Forget();

            /*
             //Create a new SphereGameObjectPool and prepool 10 objects
             //This pool is not registered in the SharedPool, so you can't get it later using SharedPool.Of<SphereGameObjectPool>()
            var pool = new SphereGameObjectPool();
            pool.Prefab = new GameObjectPrefab() {Parent = poolParent1, PrepoolAmount = 10, Source = this.prefab2};
            pool.Prepool();
            */
            //Create a new SphereGameObjectPool and prepool 10 objects
            //This pool will be automatically registered in the SharedPool, so you can globally get it later using SharedPool.Of<SphereGameObjectPool>()
            var pool2 = SharedPool.Of<SphereGameObjectPool>();
            pool2.Prefab = new GameObjectPrefab() {Parent = poolParent1, PrepoolAmount = 10, Source = this.prefab1};
            pool2.Prepool();
            
            pool4 = new GameObjectPool(new GameObjectPrefab(){Parent = poolParent2, PrepoolAmount = 100, Source = this.prefab2});
        }

        private async void OnGUI()
        {
            //manually get the SphereGameObjectPool then rent and spawn some objects
            if (GUI.Button(new Rect(0, 0, 300, 50), "Spawn in SphereGameObjectPool"))
            {
                var pool = SharedPool.Of<SphereGameObjectPool>();
                for (int i = 0; i < 13; i++)
                {
                    var go = await pool.Rent();
                    go.transform.position = new Vector3(UnityEngine.Random.Range(-10, 10),
                        UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
                    go.SetActive(true);
                    this.myGameObjects.Add(go);
                }
            }

            //manually get the SphereGameObjectPool then return and despawn some objects
            if (GUI.Button(new Rect(0, 100, 300, 50), "Despawn in SphereGameObjectPool"))
            {
                var pool = SharedPool.Of<SphereGameObjectPool>();
                //despawn first 7 objects
                for (int i = 0; i < 13; i++)
                {
                    var go = this.myGameObjects[i];
                    pool.Return(go);
                    //myGameObjects.RemoveAt(i);
                }

                /*
                 you can despawn all the list: pool.Return(this.myGameObjects);
                 */
            }
            
            if (GUI.Button(new Rect(0, 200, 150, 50), "Spawn in pool4"))
            {
                for (int i = 0; i < 100; i++)
                {
                    var go = await this.pool4.Rent();
                    go.transform.position = new Vector3(UnityEngine.Random.Range(-10, 10),
                        UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
                    go.SetActive(true);
                    this.pool4Objects.Add(go);
                }
                Debug.Log("Rent 100 game objects in pool4");
                Debug.Log("There is " + this.pool4.Count() + " objects in pool4");
            }
            
            if (GUI.Button(new Rect(0, 300, 150, 50), "Despawn in pool4"))
            {
                //return random 50 times in pool4, may some objects will be returned multiple times
                for (int i = 0; i < 50; i++)
                {
                    var go = this.pool4Objects[UnityEngine.Random.Range(0, this.pool4Objects.Count)];
                    this.pool4.Return(go);
                }
                Debug.Log("Return random 50 times game objects in pool4");
                Debug.Log("There is " + this.pool4.Count() + " objects in pool4");
            }
            
        }

        private void OnDestroy()
        {
            //manually dispose the pool4
            this.pool4.Dispose();
        }
    }
}