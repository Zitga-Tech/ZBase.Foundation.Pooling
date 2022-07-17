using Collections.Pooled;

namespace System.Pooling
{
    public static partial class Pool_TKey_T_Extensions
    {
        public static IReturnable<TKey, T> Return<TEnumerable, TKey, T>(this IReturnable<TKey, T> pool, TKey key, TEnumerable instances)
            where TEnumerable : System.Collections.Generic.IEnumerable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            foreach (var instance in instances)
            {
                pool.Return(key, instance);
            }

            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, T[] instances)
            where TPool : IReturnable<TKey, T>
            where T : class
            => Return(pool, key, instances.AsSpan());

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in Span<T> instances)
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            for (int i = 0, len = instances.Length; i < len; i++)
            {
                pool.Return(key, instances[i]);
            }

            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in ReadOnlySpan<T> instances)
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            for (int i = 0, len = instances.Length; i < len; i++)
            {
                pool.Return(key, instances[i]);
            }

            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key, in ReadOnlySpan<Entry<T>> entries)
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            for (int i = 0, len = entries.Length; i < len; i++)
            {
                Entry<T> entry = entries[i];

                if (entry.Next >= -1)
                {
                    pool.Return(key, entry.Value);
                }
            }

            return pool;
        }
    }
}
