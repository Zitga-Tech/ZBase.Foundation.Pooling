using System;

namespace Unity.Pooling
{
    public static class DefaultDestroyHandler<T> where T : UnityEngine.Object
    {
        private static Action<T> s_default = Destroy;

        private static void Destroy(T instance)
            => UnityEngine.Object.Destroy(instance);

        public static void Set(Action<T> handler)
            => s_default = handler ?? throw new ArgumentNullException(nameof(handler));

        public static Action<T> Get()
            => s_default ?? Destroy;
    }
}
