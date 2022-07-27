using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public static class SharedPool
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Of<T>() where T : IPool, new()
            => SharedInstance<T>.Instance;

        private static class SharedInstance<T> where T : IPool, new()
        {
            public static readonly T Instance = new T();
        }
    }
}