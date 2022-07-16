﻿using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public static partial class PoolDisposableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DisposableContext<T> Disposable<T>(this IPool<T> pool)
            where T : class
            => new DisposableContext<T>(pool);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DisposableContext<TKey, T> Disposable<TKey, T>(this IPool<TKey, T> pool)
            where T : class
            => new DisposableContext<TKey, T>(pool);
    }
}