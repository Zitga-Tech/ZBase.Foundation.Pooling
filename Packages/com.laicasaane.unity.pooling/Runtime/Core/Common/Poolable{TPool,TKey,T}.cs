using System;
using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public readonly struct Poolable<TPool, TKey, T> : IDisposable
        where TPool : IReturnable<TKey, T>
        where T : class
    {
        public readonly TPool Pool;
        public readonly TKey Key;
        public readonly T Instance;

        internal Poolable(TPool pool, TKey key, T instance)
        {
            Pool = pool;
            Key = key;
            Instance = instance;
        }

        public void Dispose()
        {
            Pool?.Return(Key, Instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T(in Poolable<TPool, TKey, T> poolable)
            => poolable.Instance;
    }
}