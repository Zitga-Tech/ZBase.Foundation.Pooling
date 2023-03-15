using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Collections.Pooled.Generic;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;
using Grid = Sample.Environment.Grid;

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

        private Grid _grid = new Grid(20, 15, true);
        private async UniTaskVoid Start()
        {
            /*
            //GameObjectPool do not have implementation of Prepool
            var pool1 = new GameObjectPool();
            pool1.Prefab = new GameObjectPrefab() {Parent = poolParent1, Source = this.prefab1};
            var item = await pool1.Rent();
            item.transform.position = this._grid.GetAvailableSlot().position;
            */

            /*
             //Create a new CustomGameObjectPool and prepool 10 objects
             //This pool is not registered in the SharedPool, so you can't get it later using SharedPool.Of<CustomGameObjectPool>()
            var pool = new CustomGameObjectPool();
            pool.Prefab = new GameObjectPrefab() {Parent = poolParent1, PrepoolAmount = 10, Source = this.prefab2};
            pool.Prepool();
            */
            //Create a new CustomGameObjectPool and prepool 10 objects
            //This pool will be automatically registered in the SharedPool, so you can globally get it later using SharedPool.Of<CustomGameObjectPool>()
            var pool2 = SharedPool.Of<CustomGameObjectPool>();
            pool2.Prefab = new GameObjectPrefab() {Parent = poolParent1, PrepoolAmount = 10, Source = this.prefab1};
            pool2.Prepool();
            
            pool4 = new GameObjectPool(new GameObjectPrefab(){Parent = poolParent2, PrepoolAmount = 100, Source = this.prefab2});
        }

        private async void OnGUI()
        {
            //manually get the CustomGameObjectPool then rent and spawn some objects
            if (GUI.Button(new Rect(0, 0, 300, 50), "Spawn in Shared Pool"))
            {
                var pool = SharedPool.Of<CustomGameObjectPool>();
                for (int i = 0; i < 50; i++)
                {
                    var go = await pool.Rent();
                    go.transform.position = this._grid.GetAvailableSlot().position;
                    go.SetActive(true);
                    this.myGameObjects.Add(go);
                }
            }

            //manually get the CustomGameObjectPool then return and despawn some objects
            if (GUI.Button(new Rect(0, 100, 300, 50), "Despawn in SharedPool"))
            {
                var pool = SharedPool.Of<CustomGameObjectPool>();
                //despawn first 7 objects
                for (int i = 0; i < 50; i++)
                {
                    var go = this.myGameObjects[i];
                    pool.Return(go);
                    this._grid.FreeSlot(go.transform.position);
                }

                /*
                 you can despawn all the list: pool.Return(this.myGameObjects);
                 */
            }
            
            if (GUI.Button(new Rect(0, 200, 150, 50), "Spawn in Pool 4"))
            {
                for (int i = 0; i < 100; i++)
                {
                    var go = await this.pool4.Rent();
                    go.transform.position = this._grid.GetAvailableSlot().position;
                    go.SetActive(true);
                    this.pool4Objects.Add(go);
                }
                Debug.Log("Rent 100 game objects in Pool 4");
                Debug.Log("There is " + this.pool4.Count() + " objects in Pool 4");
            }
            
            if (GUI.Button(new Rect(0, 300, 150, 50), "Despawn in Pool 4"))
            {
                //return random 50 times in pool4, may some objects will be returned multiple times
                for (int i = 0; i < 50; i++)
                {
                    var go = this.pool4Objects[UnityEngine.Random.Range(0, this.pool4Objects.Count)];
                    this.pool4.Return(go);
                    this._grid.FreeSlot(go.transform.position);
                }
                Debug.Log("Return random 50 times game objects in Pool 4");
                Debug.Log("There is " + this.pool4.Count() + " objects in Pool 4");
            }
            
        }

        private void OnDestroy()
        {
            //manually dispose the pool4
            this.pool4.Dispose();
        }
    }
}