using System;
using System.Collections.Generic;
using System.Collections.Generic.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;

namespace Pooling.Sample
{
    public class Demo : MonoBehaviour
    {
        private ListPool<int> _listPool;
        private HashSetPool<int> _hashSetPool;
        private DictionaryPool<int, string> _dictionaryPool;
        private GameObjectPool _gameObjectPool;
        private Pool<Foo> _fooPool;
        private AsyncPool<Foo> _asyncFooPool;
        private StackPool<int> _stackPool;
        private QueuePool<int> _queuePool;

        private ZBase.Collections.Pooled.Generic.List<int> myList;

        [SerializeField] private GameObject prefab;
        [SerializeField] private RectTransform canvas;

        async void Start()
        {
            this._listPool = new ListPool<int>();
            
            var rentList = this._listPool.Rent();
            for (int i = 0; i < 10; i++)
            {
                rentList.Add(i);
            }
        
            this._listPool.Return(rentList);
        
            this._hashSetPool = SharedPool.Of<HashSetPool<int>>();
            
            var rentHashSet = this._hashSetPool.Rent();
            
            for (int i = 0; i < 10; i++)
            {
                rentHashSet.Add(i);
            }
        
            this._dictionaryPool = SharedPool.Of<DictionaryPool<int, string>>();
            var rentDictionary = this._dictionaryPool.Rent();
            for (int i = 0; i < 10; i++)
            {
                rentDictionary.Add(i, i.ToString());
            }
            this._dictionaryPool.Return(rentDictionary);
        
            this._fooPool = new Pool<Foo>();
            var foo = _fooPool.Rent();
            foo.Name = "Foo";
            Debug.Log(foo.Name);
        
            var gameObjectPrefab = new GameObjectPrefab() {
                Parent = this.transform, PrepoolAmount = 40, Source = this.prefab
            };
            _gameObjectPool = new GameObjectPool(gameObjectPrefab);
        
            for (int i = 0; i < 5; i++)
            {
                var go = await _gameObjectPool.Rent();
            }
        
            await UniTask.Delay(1000);
            _gameObjectPool.Return(this.transform.GetChild(0).gameObject);
        
            var newListPool1 = SharedPool.Of<ListPool<int>>();
            var newRentList = newListPool1.Rent();
            for (int i = 0; i < 10; i++)
            {
                newRentList.Add(i);
            }
        
            //do something with newRentList
            newListPool1.Return(newRentList);
        
            var newListPool2 = SharedPool.Of<ListPool<int>>();
            var newRentList2 = newListPool2.Rent();
            for (int i = 0; i < 10; i++)
            {
                newRentList2.Add(i);
            }
        
            var newListPool3 = SharedPool.Of<ListPool<int>>();
            var newRentList3 = newListPool3.Rent();
            for (int i = 0; i < 10; i++)
            {
                newRentList3.Add(i);
            }
        
            var newListPool4 = SharedPool.Of<ListPool<int>>();
            var newRentList4 = newListPool4.Rent();
            for (int i = 0; i < 10; i++)
            {
                newRentList4.Add(i);
            }
        
            _asyncFooPool = SharedPool.Of<AsyncPool<Foo>>();
            var asyncFoo = await _asyncFooPool.Rent();
            asyncFoo.Name = "AsyncFoo";
        
            // _stackPool = SharedPool.Of<StackPool<int>>();
            // var stack = _stackPool.Rent();
            // for (int i = 0; i < 10; i++)
            // {
            //     stack.Push(i);
            // }
        
            _queuePool = SharedPool.Of<QueuePool<int>>();
            var queue = _queuePool.Rent();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
        }

        private async UniTask UpdateRentNewItems()
        {
            var newListPool = this._listPool.Rent();
            for (int i = 0; i < 10; i++)
            {
                newListPool.Add(i);
            }

            _listPool.Return(newListPool);

            var newDictionaryPool = SharedPool.Of<DictionaryPool<int, string>>();
            var dict = newDictionaryPool.Rent();
            for (int i = 0; i < 10; i++)
            {
                dict.Add(i, i.ToString());
            }

            newDictionaryPool.Return(dict);

            var newHashSetPool = SharedPool.Of<HashSetPool<int>>();
            var hashSet = newHashSetPool.Rent();
            for (int i = 0; i < 10; i++)
            {
                hashSet.Add(i);
            }

            newHashSetPool.Return(hashSet);

            var newFooPool = SharedPool.Of<Pool<Foo>>();
            var foo = newFooPool.Rent();
            foo.Name = "Foo1";
            newFooPool.Return(foo);

            var newAsyncFooPool = SharedPool.Of<AsyncPool<Foo>>();
            var asyncFoo = await newAsyncFooPool.Rent();
            asyncFoo.Name = "AsyncFoo1";
            newAsyncFooPool.Return(asyncFoo);

            var newStackPool = SharedPool.Of<StackPool<int>>();
            var stack = newStackPool.Rent();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }
            //newStackPool.Return(stack);

            var newQueuePool = SharedPool.Of<QueuePool<int>>();
            var queue = newQueuePool.Rent();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            newQueuePool.Return(queue);

            for (int i = 0; i < 5; i++)
            {
                this._gameObjectPool.Rent().Forget();
            }

            this._gameObjectPool.Return(this.transform.GetChild(0).gameObject);
            this._gameObjectPool.ReleaseInstances(0);
        }

        private WeakReference<Stack<int>> _weakStack;
        private void OnGUI()
        {
            if (GUILayout.Button("Update Stack Pool 1"))
            {
                var stackPool = SharedPool.Of<StackPool<int>>();
                
                var stack1 = stackPool.Rent();
                for (var i = 0; i < 10; i++)
                {
                    stack1.Push(i);
                }
                Debug.Log(stack1.GetHashCode());
                stackPool.Return(stack1);
                this._weakStack = new System.WeakReference<System.Collections.Generic.Stack<int>>(stack1);
            }
            
            if (GUILayout.Button("Check Alive"))
            {
                var stackPool = SharedPool.Of<StackPool<int>>();
                var stack1 = stackPool.Rent();
                //log alive
                if (this._weakStack.TryGetTarget(out var stack))
                {
                    Debug.Log("Alive");
                }
                else
                {
                    Debug.Log("Dead");
                }
                
                //log stackPool instance id 
                Debug.Log(stack1.GetHashCode());
            }
            
            if (GUILayout.Button("Update Items"))
            {
                UpdateRentNewItems().Forget();
            }

            if (GUILayout.Button("Update Stack Pool"))
            {
                var stackPool = SharedPool.Of<StackPool<int>>();
                var stack1 = stackPool.Rent();
                var stack2 = stackPool.Rent();
                var stack3 = stackPool.Rent();
                //var stack4 = stackPool.Rent();
                //var stack5 = stackPool.Rent();
                stackPool.Return(stack1, stack2, stack3);
            }
        }
    }

    public class Foo
    {
        public string Name { get; set; }
    }
}