using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public abstract class ScriptableSource : ScriptableObject, IReleasable<UnityEngine.Object>
    {
        public abstract UniTask<UnityEngine.Object> Instantiate(Transform parent);

        public abstract void Release(UnityEngine.Object instance);
    }
}
