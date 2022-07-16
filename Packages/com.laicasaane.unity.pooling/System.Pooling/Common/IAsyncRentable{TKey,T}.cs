using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public interface IAsyncRentable<TKey, T> where T : class
    {
        UniTask<T> RentAsync(TKey key);
    }
}