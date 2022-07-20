using System;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentSource<T> : UnityObjectSource<T>
        where T : UnityEngine.Component
    {
        public ComponentSource() : base()
        { }

        public ComponentSource(T source) : base(source)
        { }
    }
}
