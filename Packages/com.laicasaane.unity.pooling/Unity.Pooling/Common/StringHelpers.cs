using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class StringHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string NameOfIfNullOrEmpty<T>(this string value)
            => string.IsNullOrEmpty(value) ? NameOf<T>.Value : value;
    }
}
