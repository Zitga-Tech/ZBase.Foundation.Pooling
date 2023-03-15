using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Collections.Pooled.Generic;
using ZBase.Foundation.Pooling.ScriptablePools;

namespace Pooling.Sample
{
    public class ScriptableGameObjectPoolingSample : MonoBehaviour
    {
        public ScriptableGameObjectPool pool;
        public List<Vector3> occupiedPositions = new List<Vector3>();
        public List<GameObject> spawnedUnits = new List<GameObject>();

        private async void Start()
        {
            pool.Parent = transform;
            await this.pool.Prepool(gameObject.GetCancellationTokenOnDestroy());
        }

        private async void OnGUI()
        {
            //spawn
            if (GUI.Button(new Rect(0, 0, 150, 50), "Spawn"))
            {
                //100 units
                for (int i = 0; i < 100; i++)
                {
                    await Spawn();
                }
            }

            //despawn all
            if (GUI.Button(new Rect(0, 100, 150, 50), "Despawn All"))
            {
                DespawnAll();
            }
            
            //release
            if (GUI.Button(new Rect(0, 200, 150, 50), "Release Kept 10"))
            {
                Release();
            }
        }

        private async UniTask Spawn()
        {
            var unit = await this.pool.Rent();
            //random position in range (30,0,-15) to (30,0,15)
            var position = new Vector3(UnityEngine.Random.Range(-30, 30), 0, UnityEngine.Random.Range(-15, 15));
            //check if position is occupied
            while (this.occupiedPositions.Contains(position))
            {
                position = new Vector3(UnityEngine.Random.Range(-30, 30), 0, UnityEngine.Random.Range(-15, 15));
            }

            unit.transform.position = position;
            unit.SetActive(true);
            this.occupiedPositions.Add(position);
            spawnedUnits.Add(unit);
        }

        //Despawn all units
        private void DespawnAll()
        {
            foreach (var unit in this.spawnedUnits)
            {
                this.pool.Return(unit);
            }
        }

        private void Release()
        {
            this.pool.ReleaseInstances(10);
        }

        private void OnDisable()
        {
            foreach (var unit in this.spawnedUnits)
            {
                this.pool.Return(unit);
            }
        }
    }
}