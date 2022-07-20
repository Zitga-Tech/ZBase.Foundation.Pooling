using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static class SourceExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Validate<TSource, TObject>(this ILoadableSource<TSource, TObject> source)
            where TObject : class
            => source != null && source.Source != null;
    }
}
