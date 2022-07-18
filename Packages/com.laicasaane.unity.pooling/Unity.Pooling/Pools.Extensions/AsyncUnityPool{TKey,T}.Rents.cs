using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Collections.Pooled;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public static partial class AsyncUnityPool_TKey_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<TPool> RentAsync<TPool, TKey, T>(this TPool pool, TKey key, string name, T[] output)
            where TPool : IAsyncNamedRentable<TKey, T>
            where T : class
            => await RentAsync(pool, key, name, output, output?.Length ?? 0);

        public static async UniTask<TPool> RentAsync<TPool, TKey, T>(this TPool pool, TKey key, string name, T[] output, int count)
            where TPool : IAsyncNamedRentable<TKey, T>
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
                output[i] = await pool.RentAsync(key, $"{name}_{i}");
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<IAsyncNamedRentable<TKey, T>> RentAsync<TKey, T, TOutput>(this IAsyncNamedRentable<TKey, T> pool, TKey key, string name, TOutput output)
            where TOutput : ICollection<T>
            where T : class
            => await RentAsync(pool, key, name, output, 1);

        public static async UniTask<IAsyncNamedRentable<TKey, T>> RentAsync<TKey, T, TOutput>(this IAsyncNamedRentable<TKey, T> pool, TKey key, string name, TOutput output, int count)
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
                output.Add(await pool.RentAsync(key, $"{name}_{i}"));
            }

            return pool;
        }

        public static async UniTask<IAsyncNamedRentable<TKey, T>> RentAsync<TKey, T, TKeys, TOutput>(this IAsyncNamedRentable<TKey, T> pool, TKeys keys, string name, TOutput output)
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
                    output.Add(new KeyValuePair<TKey, T>(key, await pool.RentAsync(key, $"{key}_{name}")));
                }
                catch
                { }
            }

            return pool;
        }

        public static async UniTask<IAsyncNamedRentable<TKey, T>> RentAsync<TKey, T, TOutput>(this IAsyncNamedRentable<TKey, T> pool, TKey[] keys, string name, TOutput output)
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

            for (int i = 0, len = keys.Length; i < len; i++)
            {
                TKey key = keys[i];

                if (key is null)
                    continue;

                try
                {
                    output.Add(new KeyValuePair<TKey, T>(key, await pool.RentAsync(key, $"{key}_{name}")));
                }
                catch
                { }
            }

            return pool;
        }
    }
}