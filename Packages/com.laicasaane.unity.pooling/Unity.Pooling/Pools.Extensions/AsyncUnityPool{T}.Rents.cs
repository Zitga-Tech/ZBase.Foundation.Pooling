using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Collections.Pooled;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public static partial class AsyncUnityPool_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<TPool> RentAsync<TPool, T>(this TPool pool, string name, T[] output)
            where TPool : IAsyncNamedRentable<T>
            where T : class
            => await RentAsync(pool, name, output, output?.Length ?? 0);

        public static async UniTask<TPool> RentAsync<TPool, T>(this TPool pool, string name, T[] output, int count)
            where TPool : IAsyncNamedRentable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            if ((uint)count > (uint)output.Length)
                ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();

            for (var i = 0; i < count; i++)
            {
                output[i] = await pool.RentAsync($"{name}_{i}");
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<IAsyncNamedRentable<T>> RentAsync<T, TOutput>(this IAsyncNamedRentable<T> pool, string name, TOutput output)
            where TOutput : ICollection<T>
            where T : class
            => await RentAsync(pool, name, output, 1);

        public static async UniTask<IAsyncNamedRentable<T>> RentAsync<T, TOutput>(this IAsyncNamedRentable<T> pool, string name, TOutput output, int count)
            where TOutput : ICollection<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            for (var i = 0; i < count; i++)
            {
                try
                {
                    output.Add(await pool.RentAsync($"{name}_{i}"));
                }
                catch
                { }
            }

            return pool;
        }
    }
}