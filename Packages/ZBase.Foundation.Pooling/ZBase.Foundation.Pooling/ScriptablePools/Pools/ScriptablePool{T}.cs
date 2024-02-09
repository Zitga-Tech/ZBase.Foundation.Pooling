using System;
using System.Threading;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.ScriptablePools
{
    public class ScriptablePool<T>
        : ScriptableObject, IUnityPool<T, ScriptablePrefab>, IPrepoolable, IHasParent
        where T : UnityEngine.Object
    {
        [SerializeField]
        private ScriptablePrefab _prefab;

        [SerializeField]
        private bool _prepoolOnStart = false;

        private readonly ScriptablePool _pool = new ScriptablePool();
        private readonly ScriptablePrepooler _prepooler = default;

        public bool PrepoolOnStart
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolOnStart;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolOnStart = value;
        }

        public ScriptablePrefab Prefab
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prefab = value;
        }

        public Transform Parent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab.Parent;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (value == false)
                {
                    ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
                }

                _prefab.Parent = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count()
            => _pool.Count();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask Prepool(CancellationToken cancelToken)
            => await _prepooler.Prepool(_prefab, _pool, Parent, cancelToken);

        public void ReleaseInstances(int keep, Action<T> onReleased = null)
        {
            void OnRelease(UnityEngine.Object instance)
            {
                if (onReleased != null && instance is T instanceT)
                {
                    onReleased(instanceT);
                    return;
                }

                _prefab?.Release(instance);
            }

            _pool.ReleaseInstances(keep, OnRelease);
        }

        public async UniTask<T> Rent()
        {
            _pool.Prefab = _prefab;

            var instance = await _pool.Rent();

            if (instance is T instanceT)
            {
                await RentPostprocess(instanceT, default);
                return instanceT;
            }

            if (instance is GameObject gameObject)
            {
                if (gameObject.TryGetComponent<T>(out var component))
                {
                    await RentPostprocess(component, default);
                    return component;
                }
            }

            throw ThrowHelper.GetInvalidCastException<T>(instance.GetType());
        }

        public async UniTask<T> Rent(CancellationToken cancelToken)
        {
            _pool.Prefab = _prefab;

            var instance = await _pool.Rent(cancelToken);

            if (instance is T instanceT)
            {
                await RentPostprocess(instanceT, cancelToken);
                return instanceT;
            }

            if (instance is GameObject gameObject)
            {
                if (gameObject.TryGetComponent<T>(out var component))
                {
                    await RentPostprocess(component, cancelToken);
                    return component;
                }
            }

            throw ThrowHelper.GetInvalidCastException<T>(instance.GetType());
        }

        public void Return(T instance)
        {
            if (instance == false)
                return;

            ReturnPreprocess(instance);
            _pool.Return(instance);
        }

        protected virtual void OnDestroy()
        {
            _pool.Dispose();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual UniTask RentPostprocess(T instance, CancellationToken cancelToken)
            => UniTask.CompletedTask;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }
    }
}
