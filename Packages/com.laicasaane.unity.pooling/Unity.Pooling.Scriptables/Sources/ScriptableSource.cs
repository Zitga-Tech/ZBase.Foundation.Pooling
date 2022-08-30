using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public abstract class ScriptableSource : ScriptableObject, IReleasable<Object>
    {
        public abstract UniTask<Object> Instantiate(Transform parent, CancellationToken cancelToken = default);

        public abstract void Release(Object instance);
    }
}
