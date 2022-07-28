using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Pooling
{
    public static partial class Pool_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, T[] output)
            where TPool : IRentable<T>
            => Rent(pool, output.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, T[] output, int count)
            where TPool : IRentable<T>
            => Rent(pool, output.AsSpan(), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, in Span<T> output)
            where TPool : IRentable<T>
            => Rent(pool, output, output.Length);

        public static TPool Rent<TPool, T>(this TPool pool, in Span<T> output, int count)
            where TPool : IRentable<T>
        {
            if (pool is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            if ((uint)count > (uint)output.Length)
                ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();

            for (var i = 0; i < count; i++)
            {
                output[i] = pool.Rent();
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IRentable<T> Rent<T, TOutput>(this IRentable<T> pool, TOutput output)
            where TOutput : ICollection<T>
            => Rent(pool, output, 1);

        public static IRentable<T> Rent<T, TOutput>(this IRentable<T> pool, TOutput output, int count)
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
                    output.Add(pool.Rent());
                }
                catch
                { }
            }

            return pool;
        }
    }
}
