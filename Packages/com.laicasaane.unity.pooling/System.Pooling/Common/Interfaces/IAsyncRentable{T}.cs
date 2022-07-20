using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public interface IAsyncRentable<T> where T : class
    {
        UniTask<T> RentAsync();
    }
}