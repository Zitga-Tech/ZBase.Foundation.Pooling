using UnityEngine;

namespace Unity.Pooling
{
    public interface IPrefab
    {
        int PrepoolAmount { get; set; }

        Transform Parent { get; set; }
    }
}
