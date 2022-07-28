using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public struct UnityPrepooler<T, TPrefab, TPool>
        : IPrepooler<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T>
        where TPool : IReturnable<T>
    {
        public async UniTask Prepool(TPrefab prefab, TPool pool, Transform defaultParent)
        {
            if (prefab == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.prefab);

            if (pool == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            if (prefab.PrepoolAmount <= 0)
                return;

            if (prefab.Parent == false && defaultParent)
                prefab.Parent = defaultParent;

            for (int i = 0, count = prefab.PrepoolAmount; i < count; i++)
            {
                var instance = await prefab.Instantiate();
                pool.Return(instance);
            }
        }
    }
}
