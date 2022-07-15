using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IAsyncRentable<TKey, T> where T : class
    {
        UniTask<T> RentAsync(TKey key);
    }
}