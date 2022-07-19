using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public class UnityPrepooler<TKey, T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<TKey, T>
        where TPool : IReturnable<TKey, T>
    {
        public async UniTask Prepool(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (pool == null)
                throw new NullReferenceException(nameof(pool));

            if (prefab.Validate() == false || prefab.PrepoolAmount <= 0)
                return;

            var source = prefab.Source;
            var key = prefab.Key;
            var parent = prefab.Parent ? prefab.Parent : defaultParent;

            if (prefab.PrepoolTiming == Timing.NextFrame)
            {
                for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(source, parent, true);
                    pool.Return(key, instance);

                    await UniTask.NextFrame();
                }
            }
            else
            {
                var timing = prefab.PrepoolTiming.ToPlayerLoopTiming();

                for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(source, parent, true);
                    pool.Return(key, instance);

                    await UniTask.Yield(timing);
                }
            }
        }
    }
}