using Collections.Pooled;

namespace Unity.Pooling
{
    public static class UnityObjectExtensions
    {
        public static KVPair<int, T> ToKVPair<T>(this T obj)
            where T : UnityEngine.Object
        {
            if (obj == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.obj);

            return new KVPair<int, T>(obj.GetInstanceID(), obj);
        }
    }
}
