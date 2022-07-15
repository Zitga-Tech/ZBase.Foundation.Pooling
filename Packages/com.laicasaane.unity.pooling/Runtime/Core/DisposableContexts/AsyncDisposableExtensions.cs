﻿using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    public static partial class AsyncDisposableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncDisposableContext<T> Disposable<T>(this IAsyncPool<T> pool)
            where T : class
            => new AsyncDisposableContext<T>(pool);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncDisposableContext<TKey, T> Disposable<TKey, T>(this IAsyncPool<TKey, T> pool)
            where T : class
            => new AsyncDisposableContext<TKey, T>(pool);
    }
}
