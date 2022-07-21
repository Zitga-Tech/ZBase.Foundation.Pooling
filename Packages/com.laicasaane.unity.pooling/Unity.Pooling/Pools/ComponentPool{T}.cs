//using System.Pooling;
//using System.Runtime.CompilerServices;
//using UnityEngine;

//namespace Unity.Pooling
//{
//    public class ComponentPool<T>
//        : UnityPool<T, T, ComponentSource<T>, ComponentPrefab<T, ComponentSource<T>>, TInstantiator>
//        where T : UnityEngine.Component
//        where TSource : ILoadableSource<T, T>
//        where TPrefab : IPrefab<T, T, TSource>
//        where TInstantiator : IInstantiator<T, TPrefab>, new()
//    {
//        public ComponentPool()
//            : base(null, default, null)
//        { }

//        public ComponentPool(TPrefab prefab, Transform defaultParent = null)
//            : base(null, prefab, defaultParent)
//        { }

//        public ComponentPool(UniqueQueue<int, T> queue, TPrefab prefab, Transform defaultParent = null)
//            : base(queue, prefab, defaultParent)
//        { }

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        protected sealed override void ReturnPreprocess(T instance)
//        {
//            if (instance.gameObject.activeSelf)
//                instance.gameObject.SetActive(false);
//        }
//    }
//}
