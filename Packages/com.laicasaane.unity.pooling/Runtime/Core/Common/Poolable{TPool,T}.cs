using System;
using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public readonly struct Poolable<TPool, T> : IDisposable
        where TPool : IReturnable<T>
        where T : class
    {
        public readonly TPool Pool;
        public readonly T Instance;

        internal Poolable(TPool pool, T instance)
        {
            Pool = pool;
            Instance = instance;
        }

        public void Dispose()
        {
            Pool?.Return(Instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T(in Poolable<TPool, T> poolable)
            => poolable.Instance;
    }
}