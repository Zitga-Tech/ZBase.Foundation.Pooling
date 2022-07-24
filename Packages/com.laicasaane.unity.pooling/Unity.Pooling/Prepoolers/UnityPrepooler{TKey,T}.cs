using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityPrepooler<TKey, T, TSource, TInstantiator, TPrefab, TPool>
        : IAsyncPrepooler<TKey, T, TSource, TInstantiator, TPrefab, TPool>
        where T : UnityEngine.Object
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<TKey, T, TSource, TInstantiator>
        where TPool : IReturnable<TKey, T>
    {
        public async UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (prefab.IsNotNull() == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.prefab);

            if (pool == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            if (prefab.PrepoolAmount <= 0)
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