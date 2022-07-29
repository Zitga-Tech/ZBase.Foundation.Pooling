using UnityEngine;

namespace Unity.Pooling.Scriptables
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
