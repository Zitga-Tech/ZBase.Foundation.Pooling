using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public static class NewInstancer<T> where T : new()
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Instantiate() => new T();
    }
}
