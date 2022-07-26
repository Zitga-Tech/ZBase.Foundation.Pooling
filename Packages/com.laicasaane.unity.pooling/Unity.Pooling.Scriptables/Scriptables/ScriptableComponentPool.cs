using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    [CreateAssetMenu(
        fileName = "Scriptable Component Pool"
        , menuName = "Pooling/Scriptables/Pools/Component"
        , order = 1
    )]
    public class ScriptableComponentPool : ScriptablePool<Component>
    {
    }
}
