using System.Runtime.CompilerServices;
using UnityEngine;

namespace ZBase.Foundation.Pooling
{
    public static class SharedPool
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Of<T>() where T : IPool, IShareable, new()
            => SharedInstance<T>.Instance;

        private static class SharedInstance<T> where T : IPool, IShareable, new()
        {
            private static T s_instance;

            public static T Instance => s_instance;

            static SharedInstance()
            {
                Init();
            }

            /// <seealso href="https://docs.unity3d.com/Manual/DomainReloading.html"/>
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
            static void Init()
            {
                s_instance = new T();
            }
        }
    }
}