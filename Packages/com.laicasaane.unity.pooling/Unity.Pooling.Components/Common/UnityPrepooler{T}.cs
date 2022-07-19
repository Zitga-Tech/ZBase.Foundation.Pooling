using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public class UnityPrepooler<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<T>
        where TPool : IReturnable<T>
    {
        public async UniTask Prepool(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab));

            if (pool == null)
                throw new ArgumentNullException(nameof(pool));

            if (prefab.Validate() == false || prefab.PrepoolingAmount <= 0)
                return;

            var prefabObject = prefab.Prefab;
            var parent = prefab.Parent ? prefab.Parent : defaultParent;

            if (prefab.PrepoolTiming == PrepoolTiming.NextFrame)
            {
                for (int i = 0, count = prefab.PrepoolingAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(prefabObject, parent, true);
                    pool.Return(instance);

                    await UniTask.NextFrame();
                }
            }
            else
            {
                var timing = prefab.PrepoolTiming.ToPlayerLoopTiming();

                for (int i = 0, count = prefab.PrepoolingAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(prefabObject, parent, true);
                    pool.Return(instance);

                    await UniTask.Yield(timing);
                }
            }
        }
    }
}
