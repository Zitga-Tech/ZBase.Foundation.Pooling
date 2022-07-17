namespace System.Pooling
{
    public static partial class Pool_TKey_T_Returns
    {
        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
            , T p4
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
            pool.Return(key, p4);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
            pool.Return(key, p4);
            pool.Return(key, p5);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
            pool.Return(key, p4);
            pool.Return(key, p5);
            pool.Return(key, p6);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
            , T p7
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
            pool.Return(key, p4);
            pool.Return(key, p5);
            pool.Return(key, p6);
            pool.Return(key, p7);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
            , T p7
            , T p8
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
            pool.Return(key, p4);
            pool.Return(key, p5);
            pool.Return(key, p6);
            pool.Return(key, p7);
            pool.Return(key, p8);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
            , T p7
            , T p8
            , T p9
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
            pool.Return(key, p4);
            pool.Return(key, p5);
            pool.Return(key, p6);
            pool.Return(key, p7);
            pool.Return(key, p8);
            pool.Return(key, p9);
    
            return pool;
        }

        public static TPool Return<TPool, TKey, T>(this TPool pool, TKey key
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
            , T p7
            , T p8
            , T p9
            , T p10
        )
            where TPool : IReturnable<TKey, T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            pool.Return(key, p1);
            pool.Return(key, p2);
            pool.Return(key, p3);
            pool.Return(key, p4);
            pool.Return(key, p5);
            pool.Return(key, p6);
            pool.Return(key, p7);
            pool.Return(key, p8);
            pool.Return(key, p9);
            pool.Return(key, p10);
    
            return pool;
        }

    }
}
