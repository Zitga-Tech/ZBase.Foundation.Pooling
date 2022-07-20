using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class UnityPrepooler<T, S, TSource, TPrefab, TPool>
        where T : UnityEngine.Object
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
        where TPool : IReturnable<T>
    {
        public async UniTask Prepool(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab));

            if (pool == null)
                throw new ArgumentNullException(nameof(pool));

            if (prefab.Validate() == false || prefab.PrepoolAmount <= 0)
                return;

            var source = await prefab.Source.Load();
            var parent = prefab.Parent ? prefab.Parent : defaultParent;

            if (prefab.PrepoolTiming == Timing.NextFrame)
            {
                for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(source, parent, true);
                    pool.Return(instance);

                    await UniTask.NextFrame();
                }
            }
            else
            {
                var timing = prefab.PrepoolTiming.ToPlayerLoopTiming();

                for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
                {
                    var instance = UnityEngine.Object.Instantiate(source, parent, true);
                    pool.Return(instance);

                    await UniTask.Yield(timing);
                }
            }
        }
    }
}
