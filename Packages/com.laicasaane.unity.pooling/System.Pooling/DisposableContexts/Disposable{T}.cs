using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public readonly struct Disposable<T> : IDisposable
        where T : class
    {
        public readonly T Instance;

        private readonly IReturnable<T> _pool;

        internal Disposable(IReturnable<T> pool, T instance)
        {
            _pool = pool;
            Instance = instance;
        }

        public void Dispose()
        {
            _pool?.Return(Instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator T(in Disposable<T> poolable)
            => poolable.Instance;
    }
}