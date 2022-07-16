using System;
using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public readonly struct Disposable<TKey, T> : IDisposable
        where T : class
    {
        public readonly IReturnable<TKey, T> Pool;
        public readonly TKey Key;
        public readonly T Instance;

        internal Disposable(IReturnable<TKey, T> pool, TKey key, T instance)
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
        public static implicit operator T(in Disposable<TKey, T> poolable)
            => poolable.Instance;
    }
}