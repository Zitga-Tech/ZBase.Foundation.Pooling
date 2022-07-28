using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public class Pool<T> : Pool<T, Instantiator<T>>
        where T : class
    {
        public Pool()
            : base(null)
        { }

        public Pool(UniqueQueue<T> queue)
            : base(queue)
        { }
    }

    public struct Instantiator<T> : IInstantiable<T>
        where T : class
    {
        private static readonly Type s_type = typeof(T);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Instantiate()
            => (T)Activator.CreateInstance(s_type);
    }
}
