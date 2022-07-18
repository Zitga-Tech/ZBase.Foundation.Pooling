using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Collections.Pooled;

namespace Unity.Pooling
{
    public static partial class UnityPool_TKey_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, TKey, T>(this TPool pool, TKey key, string name, T[] output)
            where TPool : INamedRentable<TKey, T>
            where T : class
            => Rent(pool, key, name, output.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, TKey, T>(this TPool pool, TKey key, string name, T[] output, int count)
            where TPool : INamedRentable<TKey, T>
            where T : class
            => Rent(pool, key, name, output.AsSpan(), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, TKey, T>(this TPool pool, TKey key, string name, in Span<T> output)
            where TPool : INamedRentable<TKey, T>
            where T : class
            => Rent(pool, key, name, output, output.Length);

        public static TPool Rent<TPool, TKey, T>(this TPool pool, TKey key, string name, in Span<T> output, int count)
            where TPool : INamedRentable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if ((uint)count > (uint)output.Length)
                ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();

            name = name.NameOfIfNullOrEmpty<T>();

            for (var i = 0; i < count; i++)
            {
                output[i] = pool.Rent(key, $"{name}_{i}");
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static INamedRentable<TKey, T> Rent<TKey, T, TOutput>(this INamedRentable<TKey, T> pool, TKey key, string name, TOutput output)
            where TOutput : ICollection<T>
            where T : class
            => Rent(pool, key, name, output, 1);

        public static INamedRentable<TKey, T> Rent<TKey, T, TOutput>(this INamedRentable<TKey, T> pool, TKey key, string name, TOutput output, int count)
            where TOutput : ICollection<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            if (count < 0)
                ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();

            name = name.NameOfIfNullOrEmpty<T>();

            for (var i = 0; i < count; i++)
            {
                output.Add(pool.Rent(key, $"{name}_{i}"));
            }

            return pool;
        }

        public static INamedRentable<TKey, T> Rent<TKey, T, TKeys, TOutput>(this INamedRentable<TKey, T> pool, TKeys keys, string name, TOutput output)
            where TKeys : IEnumerable<TKey>
            where TOutput : ICollection<KeyValuePair<TKey, T>>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (keys is null)
                throw new ArgumentNullException(nameof(keys));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            name = name.NameOfIfNullOrEmpty<T>();

            foreach (var key in keys)
            {
                if (key is null)
                    continue;

                try
                {
                    output.Add(new KeyValuePair<TKey, T>(key, pool.Rent(key, $"{key}_{name}")));
                }
                catch
                { }
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static INamedRentable<TKey, T> Rent<TKey, T, TOutput>(this INamedRentable<TKey, T> pool, TKey[] keys, string name, TOutput output)
            where TOutput : ICollection<KeyValuePair<TKey, T>>
            where T : class
            => Rent(pool, (ReadOnlySpan<TKey>)keys, name, output);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static INamedRentable<TKey, T> Rent<TKey, T, TOutput>(this INamedRentable<TKey, T> pool, in Span<TKey> keys, string name, TOutput output)
            where TOutput : ICollection<KeyValuePair<TKey, T>>
            where T : class
            => Rent(pool, (ReadOnlySpan<TKey>)keys, name, output);

        public static INamedRentable<TKey, T> Rent<TKey, T, TOutput>(this INamedRentable<TKey, T> pool, in ReadOnlySpan<TKey> keys, string name, TOutput output)
            where TOutput : ICollection<KeyValuePair<TKey, T>>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            name = name.NameOfIfNullOrEmpty<T>();

            for (int i = 0, len = keys.Length; i < len; i++)
            {
                ref readonly TKey key = ref keys[i];

                if (key is null)
                    continue;

                try
                {
                    output.Add(new KeyValuePair<TKey, T>(key, pool.Rent(key, $"{key}_{name}")));
                }
                catch
                { }
            }

            return pool;
        }
    }
}
