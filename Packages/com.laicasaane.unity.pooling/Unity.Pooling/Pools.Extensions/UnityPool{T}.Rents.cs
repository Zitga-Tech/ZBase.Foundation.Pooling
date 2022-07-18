using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Collections.Pooled;

namespace Unity.Pooling
{
    public static partial class UnityPool_T_Rents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, string name, T[] output)
            where TPool : INamedRentable<T>
            where T : class
            => Rent(pool, name, output.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, string name, T[] output, int count)
            where TPool : INamedRentable<T>
            where T : class
            => Rent(pool, name, output.AsSpan(), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Rent<TPool, T>(this TPool pool, string name, in Span<T> output)
            where TPool : INamedRentable<T>
            where T : class
            => Rent(pool, name, output, output.Length);

        public static TPool Rent<TPool, T>(this TPool pool, string name, in Span<T> output, int count)
            where TPool : INamedRentable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if ((uint)count > (uint)output.Length)
                ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();

            name = name.NameOfIfNullOrEmpty<T>();

            for (var i = 0; i < count; i++)
            {
                output[i] = pool.Rent($"{name}_{i}");
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static INamedRentable<T> Rent<T, TOutput>(this INamedRentable<T> pool, string name, TOutput output)
            where TOutput : ICollection<T>
            where T : class
            => Rent(pool, name, output, 1);

        public static INamedRentable<T> Rent<T, TOutput>(this INamedRentable<T> pool, string name, TOutput output, int count)
            where TOutput : ICollection<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            name = name.NameOfIfNullOrEmpty<T>();

            for (var i = 0; i < count; i++)
            {
                try
                {
                    output.Add(pool.Rent($"{name}_{i}"));
                }
                catch
                { }
            }

            return pool;
        }
    }
}
