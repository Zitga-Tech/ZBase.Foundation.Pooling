using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public abstract class ScriptablePool<T>
        : ScriptableObject, IUnityPool<T>, IAsyncPrepoolable, IHasParent
        where T : UnityEngine.Object
    {
        [SerializeField]
        private UnityObjectPrefab _prefab;

        [SerializeField]
        private bool _prepoolOnStart = false;

        private readonly UnityObjectPool _pool = new UnityObjectPool();
        private readonly UnityObjectPrepooler _prepooler = new UnityObjectPrepooler();

        public bool PrepoolOnStart
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolOnStart;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolOnStart = value;
        }

        public Transform Parent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab.Parent;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prefab.Parent = value ?? throw new ArgumentNullException(nameof(value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count()
            => _pool.Count();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(T instance)
            => _pool.Return(instance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask PrepoolAsync()
            => await _prepooler.PrepoolAsync(_prefab, _pool, Parent);

        public void ReleaseInstances(int keep, Action<T> onReleased = null)
        {
            void OnRelease(UnityEngine.Object instance)
            {
                if (onReleased != null && instance is T instanceT)
                    onReleased(instanceT);
            }

            _pool.ReleaseInstances(keep, OnRelease);
        }

        public async UniTask<T> RentAsync()
        {
            var instance = await _pool.RentAsync();

            if (instance is T instanceT)
                return instanceT;

            if (instance is GameObject gameObject)
            {
                if (gameObject.TryGetComponent<T>(out var component))
                    return component;
            }

            throw new InvalidCastException($"Cannot cast {instance.GetType()} into {typeof(T)}");
        }
    }
}
