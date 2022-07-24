using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public sealed class UnityObjectPrepooler
        : IAsyncPrepooler<UnityEngine.Object
            , ScriptableSource
            , UnityObjectPrefab
            , IReturnable<UnityEngine.Object>
        >
    {
        public async UniTask PrepoolAsync(UnityObjectPrefab prefab, IReturnable<UnityEngine.Object> pool, Transform defaultParent)
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
