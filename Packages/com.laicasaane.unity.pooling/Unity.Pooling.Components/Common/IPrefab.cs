using UnityEngine;

namespace Unity.Pooling.Components
{
    public interface IPrefab
    {
        int PrepoolAmount { get; set; }

        Timing PrepoolTiming { get; set; }

        Transform Parent { get; set; }
    }
}
