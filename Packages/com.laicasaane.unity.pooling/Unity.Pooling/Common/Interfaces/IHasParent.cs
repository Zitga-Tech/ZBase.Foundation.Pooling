using UnityEngine;

namespace Unity.Pooling
{
    public interface IHasParent
    {
        Transform Parent { get; set; }
    }
}
