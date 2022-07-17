using Collections.Pooled;

namespace System.Pooling
{
    public static partial class Pool_T_Extensions
    {
        public static IReturnable<T> Return<TEnumerable, T>(this IReturnable<T> pool, TEnumerable instances)
            where TEnumerable : System.Collections.Generic.IEnumerable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            foreach (var instance in instances)
            {
                pool.Return(instance);
            }

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool, T[] instances)
            where TPool : IReturnable<T>
            where T : class
            => Return(pool, instances.AsSpan());

        public static TPool Return<TPool, T>(this TPool pool, in Span<T> instances)
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            for (int i = 0, len = instances.Length; i < len; i++)
            {
                pool.Return(instances[i]);
            }

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool, in ReadOnlySpan<T> instances)
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            for (int i = 0, len = instances.Length; i < len; i++)
            {
                pool.Return(instances[i]);
            }

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool, in ReadOnlySpan<Entry<T>> entries)
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            for (int i = 0, len = entries.Length; i < len; i++)
            {
                Entry<T> entry = entries[i];

                if (entry.Next >= -1)
                {
                    pool.Return(entry.Value);
                }
            }

            return pool;
        }
    }
}
