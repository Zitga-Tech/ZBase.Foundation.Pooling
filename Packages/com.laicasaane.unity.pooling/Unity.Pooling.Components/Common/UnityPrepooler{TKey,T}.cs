using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public class UnityPrepooler<TKey, T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<TKey, T>
        where TPool : IReturnable<TKey, T>
    {
        public async UniTask Prepool(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (pool == null)
                throw new NullReferenceException(nameof(pool));

            if (prefab.Validate() == false || prefab.PrepoolingAmount <= 0)
                return;

            var prefabObject = prefab.Prefab;
            var key = prefab.Key;
            var parent = prefab.Parent ? prefab.Parent : defaultParent;

            if (prefab.PrepoolTiming == PrepoolTiming.NextFrame)
            {
                for (int i = 0, count = prefab.PrepoolingAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(prefabObject, parent, true);
                    pool.Return(key, instance);

                    await UniTask.NextFrame();
                }
            }
            else
            {
                var timing = prefab.PrepoolTiming.ToPlayerLoopTiming();

                for (int i = 0, count = prefab.PrepoolingAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(prefabObject, parent, true);
                    pool.Return(key, instance);

                    await UniTask.Yield(timing);
                }
            }
        }
    }
}