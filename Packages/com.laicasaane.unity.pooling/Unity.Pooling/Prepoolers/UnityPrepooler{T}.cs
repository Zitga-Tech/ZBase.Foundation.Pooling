using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class UnityPrepooler<T, S, TSource, TPrefab, TPool>
        : IAsyncPrepooler<T, S, TSource, TPrefab, TPool>
        where T : UnityEngine.Object
        where TSource : IAsyncInstantiatableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
        where TPool : IReturnable<T>
    {
        public async UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (prefab.IsNotNull() == false)
                throw new ArgumentNullException(nameof(prefab));

            if (pool == null)
                throw new ArgumentNullException(nameof(pool));

            if (prefab.PrepoolAmount <= 0)
                return;

            var parent = prefab.Parent ? prefab.Parent : defaultParent;

            for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
            {
                var instance = await prefab.InstantiateAsync(parent);
                pool.Return(instance);
            }
        }
    }
}
