using System.Runtime.CompilerServices;

namespace ZBase.Foundation.Pooling
{
    public static class SharedPool
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Of<T>() where T : IPool, IShareable, new()
            => SharedInstance<T>.Instance;

        private static class SharedInstance<T> where T : IPool, IShareable, new()
        {
            public static readonly T Instance = new T();
        }
    }
}