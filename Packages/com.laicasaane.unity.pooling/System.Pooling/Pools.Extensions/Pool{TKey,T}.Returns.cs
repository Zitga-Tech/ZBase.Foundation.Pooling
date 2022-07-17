using System.Runtime.CompilerServices;
using Collections.Pooled;

namespace System.Pooling
{
    public static partial class Pool_TKey_T_Returns
    {
        public static IReturnable<TKey, T> Return<TKey, T, TInstances>(this IReturnable<TKey, T> pool, TKey key, TInstances instances)
            where TInstances : System.Collections.Generic.IEnumerable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            foreach (var instance in instances)
            {
                pool.Return(key, instance);
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, T[] instances)
            where TPool : IReturnable<TKey, T>
            where T : class
            => Return(pool, key, instances.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in Span<T> instances)
            where TPool : IReturnable<TKey, T>
            where T : class
            => Return(pool, key, (ReadOnlySpan<T>)instances);

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in ReadOnlySpan<T> instances)
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            for (int i = 0, len = instances.Length; i < len; i++)
            {
                pool.Return(key, instances[i]);
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in Span<Entry<T>> entries)
            where TPool : IReturnable<TKey, T>
            where T : class
            => Return(pool, key, (ReadOnlySpan<Entry<T>>)entries);

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in ReadOnlySpan<Entry<T>> entries)
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            for (int i = 0, len = entries.Length; i < len; i++)
            {
                ref readonly Entry<T> entry = ref entries[i];

                if (entry.Next >= -1)
                {
                    pool.Return(key, entry.Value);
                }
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in Span<Entry<TKey, T>> entries)
            where TPool : IReturnable<TKey, T>
            where T : class
            => Return(pool, key, (ReadOnlySpan<Entry<TKey, T>>)entries);

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in ReadOnlySpan<Entry<TKey, T>> entries)
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            for (int i = 0, len = entries.Length; i < len; i++)
            {
                ref readonly Entry<TKey, T> entry = ref entries[i];

                if (entry.Next >= -1)
                {
                    pool.Return(key, entry.Value);
                }
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, TKey, T>(this TPool pool, in Span<Entry<TKey, T>> entries)
            where TPool : IReturnable<TKey, T>
            where T : class
            => Return(pool, (ReadOnlySpan<Entry<TKey, T>>)entries);

        public static TPool Return<TPool, TKey, T>(this TPool pool, in ReadOnlySpan<Entry<TKey, T>> entries)
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            for (int i = 0, len = entries.Length; i < len; i++)
            {
                ref readonly Entry<TKey, T> entry = ref entries[i];

                if (entry.Next >= -1)
                {
                    pool.Return(entry.Key, entry.Value);
                }
            }

            return pool;
        }
    }
}
