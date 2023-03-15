using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using ZBase.Collections.Pooled.Generic;
using ZBase.Foundation.Pooling;

namespace Pooling.Sample
{
    /// <summary>
    /// This sample shows how to use the AddressableColliderPoolBehaviour pool.
    /// Steps to use:
    /// 1. Add this component to a GameObject in the scene.
    /// 2. Create a pool behaviour by adding AddressableColliderPoolBehaviour to a GameObject in the scene.
    /// 3. Set up the Prefab of the pool behaviour.
    ///     3.1 Source: The address of the prefab.
    ///     3.2 Parent: The parent of the prefab.
    ///     3.3 Prepool amount: The number of prefabs to prepool.
    ///     3.4 Prepool on start: Whether to prepool on start.
    /// 4. Reference the pool behaviour in your code.
    /// 5. Rent and return units.
    /// </summary>
    public class AddressablePoolBehaviourSample1 : MonoBehaviour
    {
        [SerializeField] private AddressableColliderPoolBehaviour pool;

        private readonly List<BoxCollider> _units = new List<BoxCollider>();

        private async void Start()
        {
            await this.pool.Prepool(gameObject.GetCancellationTokenOnDestroy());
        }

        private async void OnGUI()
        {
            if(GUI.Button(new Rect(0, 0, 150, 50), "Rent All"))
            {
                await Rent(gameObject.GetCancellationTokenOnDestroy());
            }

            if (GUI.Button(new Rect(0, 100, 150, 50), "Return All"))
            {
                this.pool.Return(this._units);
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private async UniTask Rent(CancellationToken cancelToken = default)
        {
            //fill units in range (-30,0,-15) to (30,0,15) sequentially, each unit is 1x1x1
            for (int x = -20; x < 20; x++)
            {
                if(x % 2 == 0)
                    continue;
                for (int z = -15; z < 15; z++)
                {
                    if(z % 2 == 0)
                        continue;
                    var unit = await this.pool.Rent(cancelToken);
                    unit.transform.position = new Vector3(x, 0, z);
                    unit.gameObject.SetActive(true);
                    this._units.Add(unit);
                }
            }
        }
    }
}