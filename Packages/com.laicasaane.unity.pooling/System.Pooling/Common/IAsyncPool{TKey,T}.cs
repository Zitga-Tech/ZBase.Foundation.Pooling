using System;

namespace System.Pooling
{
    public interface IAsyncPool<TKey, T>
        : IPool, IAsyncRentable<TKey, T>, IReturnable<TKey, T>, ICountable<TKey>
        where T : class
    {
        /// <summary>
        /// Keeps the specified quantity and releases the pooled instances.
        /// </summary>
        /// <param name="keep"> Quantity that keep pooled instances. </param>
        void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null);
    }
}
