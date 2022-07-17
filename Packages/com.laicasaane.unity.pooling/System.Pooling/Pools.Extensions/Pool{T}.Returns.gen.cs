namespace System.Pooling
{
    public static partial class Pool_T_Returns
    {
        public static TPool Return<TPool, T>(this TPool pool
            , T p1
            , T p2
        )
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
            , T p1
            , T p2
            , T p3
        )
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
            , T p1
            , T p2
            , T p3
            , T p4
        )
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);
            pool.Return(p4);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
        )
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);
            pool.Return(p4);
            pool.Return(p5);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
        )
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);
            pool.Return(p4);
            pool.Return(p5);
            pool.Return(p6);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
            , T p7
        )
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);
            pool.Return(p4);
            pool.Return(p5);
            pool.Return(p6);
            pool.Return(p7);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
            , T p1
            , T p2
            , T p3
            , T p4
            , T p5
            , T p6
            , T p7
            , T p8
        )
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);
            pool.Return(p4);
            pool.Return(p5);
            pool.Return(p6);
            pool.Return(p7);
            pool.Return(p8);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
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
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);
            pool.Return(p4);
            pool.Return(p5);
            pool.Return(p6);
            pool.Return(p7);
            pool.Return(p8);
            pool.Return(p9);

            return pool;
        }

        public static TPool Return<TPool, T>(this TPool pool
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
            where TPool : IReturnable<T>
            where T : class
        {
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            pool.Return(p1);
            pool.Return(p2);
            pool.Return(p3);
            pool.Return(p4);
            pool.Return(p5);
            pool.Return(p6);
            pool.Return(p7);
            pool.Return(p8);
            pool.Return(p9);
            pool.Return(p10);

            return pool;
        }

    }
}
