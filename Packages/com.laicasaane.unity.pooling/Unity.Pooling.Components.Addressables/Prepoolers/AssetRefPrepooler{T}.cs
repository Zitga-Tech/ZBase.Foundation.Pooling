using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    public abstract class AssetRefPrepooler<T, TAssetRef, TPrefab, TPool>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
        where TPrefab : IPrefab<TAssetRef>
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

            var source = prefab.Source;
            var parent = prefab.Parent ? prefab.Parent : defaultParent;

            if (prefab.PrepoolTiming == Timing.NextFrame)
            {
                for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
                {
                    var instance = await InstantiateAsync(source, parent);
                    pool.Return(instance);

                    await UniTask.NextFrame();
                }
            }
            else
            {
                var timing = prefab.PrepoolTiming.ToPlayerLoopTiming();

                for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
                {
                    var instance = await InstantiateAsync(source, parent);
                    pool.Return(instance);

                    await UniTask.Yield(timing);
                }
            }
        }

        public abstract UniTask<T> InstantiateAsync(TAssetRef assetRef, Transform parent);
    }
}
