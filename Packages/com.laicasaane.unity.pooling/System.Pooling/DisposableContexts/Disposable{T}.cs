using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public readonly struct Disposable<T> : IDisposable
        where T : class
    {
        public readonly IReturnable<T> Pool;
        public readonly T Instance;

        internal Disposable(IReturnable<T> pool, T instance)
        {
            Pool = pool;
            Instance = instance;
        }

        public void Dispose()
        {
            Pool?.Return(Instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T(in Disposable<T> poolable)
            => poolable.Instance;
    }
}