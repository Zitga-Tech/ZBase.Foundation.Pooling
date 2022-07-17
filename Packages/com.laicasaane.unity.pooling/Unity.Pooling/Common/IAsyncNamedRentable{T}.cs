using System.Pooling;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IAsyncNamedRentable<T> : IAsyncRentable<T> where T : class
    {
        UniTask<T> RentAsync(string name);
    }
}