using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Collections.Pooled;

namespace System.Pooling
{
    public static partial class Pool_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, T[] output)
            where TPool : IRentable<T>
            where T : class
            => Rent(pool, output.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, T[] output, int count)
            where TPool : IRentable<T>
            where T : class
            => Rent(pool, output.AsSpan(), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, in Span<T> output)
            where TPool : IRentable<T>
            where T : class
            => Rent(pool, output, output.Length);

        public static TPool Rent<TPool, T>(this TPool pool, in Span<T> output, int count)
            where TPool : IRentable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

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
            where T : class
            => Rent(pool, output, 1);

        public static IRentable<T> Rent<T, TOutput>(this IRentable<T> pool, TOutput output, int count)
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
                    output.Add(pool.Rent());
                }
                catch
                { }
            }

            return pool;
        }
    }
}
