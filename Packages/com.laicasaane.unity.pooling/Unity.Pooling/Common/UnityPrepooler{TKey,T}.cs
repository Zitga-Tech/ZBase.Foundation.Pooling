using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class UnityPrepooler<TKey, T, S, TSource, TPrefab, TPool>
        where T : UnityEngine.Object
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<TKey, T, S, TSource>
        where TPool : IReturnable<TKey, T>
    {
        public async UniTask Prepool(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (pool == null)
                throw new NullReferenceException(nameof(pool));

            if (prefab.Validate() == false || prefab.PrepoolAmount <= 0)
                return;

            var source = await prefab.Source.Load();
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