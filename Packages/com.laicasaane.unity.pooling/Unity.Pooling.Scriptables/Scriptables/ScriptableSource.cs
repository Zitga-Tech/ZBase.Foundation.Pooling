using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public abstract class ScriptableSource : ScriptableObject
    {
        public abstract UniTask<UnityEngine.Object> InstantiateAsync(Transform parent);
    }
}
