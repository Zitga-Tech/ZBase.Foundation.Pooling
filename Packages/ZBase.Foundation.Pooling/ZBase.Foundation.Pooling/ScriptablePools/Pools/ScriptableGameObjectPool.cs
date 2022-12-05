using UnityEngine;

namespace ZBase.Foundation.Pooling.ScriptablePools
{
    [CreateAssetMenu(
        fileName = "Scriptable GameObject Pool"
        , menuName = "Pooling/Scriptables/Pools/GameObject"
        , order = 1
    )]
    public class ScriptableGameObjectPool : ScriptablePool<GameObject>
    {
    }
}
