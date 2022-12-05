using System.Runtime.CompilerServices;
using UnityEngine;

namespace ZBase.Foundation.Pooling.ScriptablePools
{
    public abstract class ScriptableSource<T> : ScriptableSource
    {
        [SerializeField]
        private T _source;

        protected T Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;
        }
    }
}
