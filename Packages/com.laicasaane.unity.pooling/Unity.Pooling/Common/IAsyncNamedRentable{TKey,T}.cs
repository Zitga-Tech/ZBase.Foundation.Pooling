using System.Pooling;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IAsyncNamedRentable<TKey, T> : IAsyncRentable<TKey, T> where T : class
    {
        UniTask<T> RentAsync(TKey key, string name);
    }
}