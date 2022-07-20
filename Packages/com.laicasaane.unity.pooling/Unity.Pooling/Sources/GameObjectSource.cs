using System;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public sealed class GameObjectSource : UnityObjectSource<GameObject>
    {
        public GameObjectSource() : base()
        { }

        public GameObjectSource(GameObject source) : base(source)
        { }
    }
}
