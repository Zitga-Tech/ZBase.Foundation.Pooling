using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Collections.Pooled;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public static partial class AsyncPool_TKey_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<TPool> RentAsync<TPool, TKey, T>(this TPool pool, TKey key, T[] output)
            where TPool : IAsyncRentable<TKey, T>
            where T : class
            => await RentAsync(pool, key, output, output?.Length ?? 0);

        public static async UniTask<TPool> RentAsync<TPool, TKey, T>(this TPool pool, TKey key, T[] output, int count)
            where TPool : IAsyncRentable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if ((uint)count > (uint)output.Length)
                ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();

            for (var i = 0; i < count; i++)
            {
                output[i] = await pool.RentAsync(key);
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<IAsyncRentable<TKey, T>> RentAsync<TKey, T, TOutput>(this IAsyncRentable<TKey, T> pool, TKey key, TOutput output)
            where TOutput : ICollection<T>
            where T : class
            => await RentAsync(pool, key, output, 1);

        public static async UniTask<IAsyncRentable<TKey, T>> RentAsync<TKey, T, TOutput>(this IAsyncRentable<TKey, T> pool, TKey key, TOutput output, int count)
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

            for (var i = 0; i < count; i++)
            {
                output.Add(await pool.RentAsync(key));
            }

            return pool;
        }

        public static async UniTask<IAsyncRentable<TKey, T>> RentAsync<TKey, T, TKeys, TOutput>(this IAsyncRentable<TKey, T> pool, TKeys keys, TOutput output)
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

            foreach (var key in keys)
            {
                if (key is null)
                    continue;

                try
                {
                    output.Add(new KeyValuePair<TKey, T>(key, await pool.RentAsync(key)));
                }
                catch
                { }
            }

            return pool;
        }

        public static async UniTask<IAsyncRentable<TKey, T>> RentAsync<TKey, T, TOutput>(this IAsyncRentable<TKey, T> pool, TKey[] keys, TOutput output)
            where TOutput : ICollection<KeyValuePair<TKey, T>>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (keys is null)
                throw new ArgumentNullException(nameof(keys));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            for (int i = 0, len = keys.Length; i < len; i++)
            {
                TKey key = keys[i];

                if (key is null)
                    continue;

                try
                {
                    output.Add(new KeyValuePair<TKey, T>(key, await pool.RentAsync(key)));
                }
                catch
                { }
            }

            return pool;
        }
    }
}