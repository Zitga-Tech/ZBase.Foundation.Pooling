using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Collections.Pooled;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public static partial class AsyncPool_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<TPool> RentAsync<TPool, T>(this TPool pool, T[] output)
            where TPool : IAsyncRentable<T>
            where T : class
            => await RentAsync(pool, output, output?.Length ?? 0);

        public static async UniTask<TPool> RentAsync<TPool, T>(this TPool pool, T[] output, int count)
            where TPool : IAsyncRentable<T>
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
                output[i] = await pool.RentAsync();
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<IAsyncRentable<T>> RentAsync<T, TOutput>(this IAsyncRentable<T> pool, TOutput output)
            where TOutput : ICollection<T>
            where T : class
            => await RentAsync(pool, output, 1);

        public static async UniTask<IAsyncRentable<T>> RentAsync<T, TOutput>(this IAsyncRentable<T> pool, TOutput output, int count)
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
                    output.Add(await pool.RentAsync());
                }
                catch
                { }
            }

            return pool;
        }
    }
}