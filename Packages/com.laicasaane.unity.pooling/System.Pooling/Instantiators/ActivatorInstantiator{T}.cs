using System.Runtime.CompilerServices;

namespace System.Pooling
{
    /// <summary>
    /// Create a new instance of <typeparamref name="T"/> via
    /// <see cref="Activator"/>.<see cref="Activator.CreateInstance(Type)"/>.
    /// </summary>
    public struct ActivatorInstantiator<T> : IInstantiable<T>
    {
        private static readonly Type s_type = typeof(T);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Instantiate()
            => (T)Activator.CreateInstance(s_type);
    }
}
