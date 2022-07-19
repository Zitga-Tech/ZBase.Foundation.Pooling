using System;
using UnityEngine;

namespace Unity.Pooling.Components
{
    public class UnityInstantiator<T, TPrefab>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T>
    {
        public T Instantiate(TPrefab prefab, Transform defaultParent)
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab));

            if (prefab.Validate() == false)
                throw new InvalidOperationException(nameof(prefab));

            var parent = prefab.Parent ? prefab.Parent : defaultParent;
            var instance = UnityEngine.Object.Instantiate(prefab.Source, parent, true);
            return instance;
        }
    }
}