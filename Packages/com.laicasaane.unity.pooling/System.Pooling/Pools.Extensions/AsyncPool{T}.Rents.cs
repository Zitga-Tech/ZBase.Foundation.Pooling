using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public static partial class AsyncPool_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<TPool> RentAsync<TPool, T>(this TPool pool, T[] output)
            where TPool : IAsyncRentable<T>
            => await RentAsync(pool, output, output?.Length ?? 0);

        public static async UniTask<TPool> RentAsync<TPool, T>(this TPool pool, T[] output, int count)
            where TPool : IAsyncRentable<T>
        {
            if (pool is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            if (output is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.output);

            if ((uint)count > (uint)output.Length)
                ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();

            for (var i = 0; i < count; i++)
            {
                output[i] = await pool.Rent();
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<IAsyncRentable<T>> RentAsync<T, TOutput>(this IAsyncRentable<T> pool, TOutput output)
            where TOutput : ICollection<T>
            => await RentAsync(pool, output, 1);

        public static async UniTask<IAsyncRentable<T>> RentAsync<T, TOutput>(this IAsyncRentable<T> pool, TOutput output, int count)
            where TOutput : ICollection<T>
        {
            if (pool is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            if (output is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.output);

            for (var i = 0; i < count; i++)
            {
                try
                {
                    output.Add(await pool.Rent());
                }
                catch
                { }
            }

            return pool;
        }
    }
}