using System.Runtime.CompilerServices;
using Collections.Pooled;

namespace System.Pooling
{
    public static partial class Pool_T_Returns
    {
        public static IReturnable<T> Return<T, TInstances>(this IReturnable<T> pool, TInstances instances)
            where TInstances : System.Collections.Generic.IEnumerable<T>
        {
            if (pool is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            foreach (var instance in instances)
            {
                pool.Return(instance);
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, T>(this TPool pool, T[] instances)
            where TPool : IReturnable<T>
            => Return(pool, instances.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, T>(this TPool pool, in Span<T> instances)
            where TPool : IReturnable<T>
            => Return(pool, (ReadOnlySpan<T>)instances);

        public static TPool Return<TPool, T>(this TPool pool, in ReadOnlySpan<T> instances)
            where TPool : IReturnable<T>
        {
            if (pool is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            for (int i = 0, len = instances.Length; i < len; i++)
            {
                pool.Return(instances[i]);
            }

            return pool;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPool Return<TPool, T>(this TPool pool, in Span<Entry<T>> entries)
            where TPool : IReturnable<T>
            => Return(pool, (ReadOnlySpan<Entry<T>>)entries);

        public static TPool Return<TPool, T>(this TPool pool, in ReadOnlySpan<Entry<T>> entries)
            where TPool : IReturnable<T>
        {
            if (pool is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.pool);

            for (int i = 0, len = entries.Length; i < len; i++)
            {
                ref readonly Entry<T> entry = ref entries[i];

                if (entry.Next >= -1)
                {
                    pool.Return(entry.Value);
                }
            }

            return pool;
        }
    }
}
