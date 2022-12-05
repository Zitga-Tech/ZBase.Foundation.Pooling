using UnityEngine;

namespace ZBase.Foundation.Pooling.ScriptablePools
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
