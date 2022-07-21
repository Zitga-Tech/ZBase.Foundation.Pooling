using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class SourceExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNull<TSource, TObject>(this IAsyncInstantiatableSource<TSource, TObject> source)
            where TObject : class
            => source != null && source.Source != null;
    }
}
