using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public readonly struct Disposable<TKey, T> : IDisposable
        where T : class
    {
        public readonly TKey Key;
        public readonly T Instance;

        private readonly IReturnable<TKey, T> _pool;

        internal Disposable(IReturnable<TKey, T> pool, TKey key, T instance)
        {
            _pool = pool;
            Key = key;
            Instance = instance;
        }

        public void Dispose()
        {
            _pool?.Return(Key, Instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator TKey(in Disposable<TKey, T> poolable)
            => poolable.Key;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator T(in Disposable<TKey, T> poolable)
            => poolable.Instance;
    }
}