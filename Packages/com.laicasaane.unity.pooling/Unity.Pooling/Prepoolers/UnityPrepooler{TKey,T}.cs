using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class UnityPrepooler<TKey, T, S, TSource, TPrefab, TPool>
        : IAsyncPrepooler<TKey, T, S, TSource, TPrefab, TPool>
        where T : UnityEngine.Object
        where TSource : IAsyncInstantiatableSource<S, T>
        where TPrefab : IPrefab<TKey, T, S, TSource>
        where TPool : IReturnable<TKey, T>
    {
        public async UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (pool == null)
                throw new NullReferenceException(nameof(pool));

            if (prefab.IsNotNull() == false || prefab.PrepoolAmount <= 0)
                return;

            var key = prefab.Key;
            var parent = prefab.Parent ? prefab.Parent : defaultParent;

            for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
            {
                var instance = await prefab.InstantiateAsync(parent);
                pool.Return(key, instance);
            }
        }
    }
}