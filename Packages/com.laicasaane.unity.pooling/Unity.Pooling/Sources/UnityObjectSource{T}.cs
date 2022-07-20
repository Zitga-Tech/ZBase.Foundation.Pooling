using System;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    [Serializable]
    public class UnityObjectSource<T> : LoadableSource<T, T>
        where T : UnityEngine.Object
    {
        public UnityObjectSource() : base()
        { }

        public UnityObjectSource(T source) : base(source)
        { }

        public override async UniTask<T> Load()
        {
            if (Source)
                return await UniTask.FromResult(Source);

            throw new NullReferenceException(nameof(Source));
        }
    }
}
