using System;
using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityPrepooler<T, TSource, TPrefab, TPool>
        : IAsyncPrepooler<T, TSource, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T, TSource>
        where TPool : IReturnable<T>
    {
        public async UniTask PrepoolAsync(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (prefab.IsNotNull() == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.prefab);

            if (pool == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            if (prefab.PrepoolAmount <= 0)
                return;

            if (prefab.Parent == false && defaultParent)
                prefab.Parent = defaultParent;

            for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
            {
                var instance = await prefab.InstantiateAsync();
                pool.Return(instance);
            }
        }
    }
}
