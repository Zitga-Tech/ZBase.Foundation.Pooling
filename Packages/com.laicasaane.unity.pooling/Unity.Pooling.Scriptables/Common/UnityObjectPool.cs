using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Scriptables
{
    [Serializable]
    public sealed class UnityObjectPool
        : IUnityPool<UnityEngine.Object>, IHasPrefab<UnityObjectPrefab>, IDisposable
    {
        private readonly UniqueQueue<int, UnityEngine.Object> _queue = new UniqueQueue<int, UnityEngine.Object>();

        [SerializeField]
        private UnityObjectPrefab _prefab;

        public UnityObjectPrefab Prefab
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prefab = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count()
            => _queue.Count;

        public void Dispose()
        {
            _queue.Dispose();
        }

        /// <inheritdoc/>
        public void ReleaseInstances(int keep, Action<UnityEngine.Object> onReleased = null)
        {
            var countRemove = _queue.Count - keep;

            while (countRemove > 0)
            {
                var instance = _queue.Dequeue();
                onReleased?.Invoke(instance.Value);
                countRemove--;
            }
        }

        public async UniTask<UnityEngine.Object> RentAsync()
        {
            if (_queue.TryDequeue(out var instance))
                return instance.Value;

            return await _prefab.InstantiateAsync();
        }

        public void Return(UnityEngine.Object instance)
        {
            if (instance == false)
                return;

            ReturnPreprocess(instance);
            _queue.Enqueue(instance.ToKVPair());
        }

        private void ReturnPreprocess(UnityEngine.Object instance)
        {
            if (instance is GameObject gameObject && gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
            else if (instance is Component component && component.gameObject.activeSelf)
            {
                component.gameObject.SetActive(false);
            }
        }
    }
}
