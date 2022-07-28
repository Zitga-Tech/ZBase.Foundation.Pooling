using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public struct UnityObjectPrepooler
        : IPrepooler<UnityEngine.Object
            , UnityObjectPrefab
            , IReturnable<UnityEngine.Object>
        >
    {
        public async UniTask Prepool(UnityObjectPrefab prefab, IReturnable<UnityEngine.Object> pool, Transform defaultParent)
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
