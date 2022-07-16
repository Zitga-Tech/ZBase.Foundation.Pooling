using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IAsyncRentable<T> where T : class
    {
        UniTask<T> RentAsync();
    }
}