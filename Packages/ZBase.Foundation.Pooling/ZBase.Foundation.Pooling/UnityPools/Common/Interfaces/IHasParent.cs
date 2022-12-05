using UnityEngine;

namespace ZBase.Foundation.Pooling.UnityPools
{
    public interface IHasParent
    {
        Transform Parent { get; set; }
    }
}
