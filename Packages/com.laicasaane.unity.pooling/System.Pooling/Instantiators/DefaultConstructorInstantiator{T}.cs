using System.Runtime.CompilerServices;

namespace System.Pooling
{
    /// <summary>
    /// Create a new instance of <typeparamref name="T"/> via default constructor.
    /// </summary>
    public struct DefaultConstructorInstantiator<T> : IInstantiable<T>
        where T : class, new()
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Instantiate()
            => new T();
    }
}
