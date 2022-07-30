# Unity.Pooling

## Dependencies

- [com.cysharp.unitask](https://github.com/Cysharp/UniTask)
- [com.laicasaane.collections.pooled](https://github.com/laicasaane/Collections.Pooled)

## Addressables support

The related modules will be enabled automatically when the [com.unity.addressables](https://docs.unity3d.com/Packages/com.unity.addressables@1.19/manual/index.html) package is installed.


# Installation

## Install via Open UPM

You can install this package from the [Open UPM](https://openupm.com/packages/com.laicasaane.unity.pooling/) registry.

More details [here](https://github.com/openupm/openupm-cli#installation).

```
openupm add com.laicasaane.unity.pooling
```

## Install via Package Manager

Or, you can add this package by opening the **Package Manager** window and entering

```
https://github.com/laicasaane/Unity.Pooling.git?path=Packages/com.laicasaane.unity.pooling
```

from the `Add package from git URL` option.


# System.Pooling

This module provides a foundation for this entire package and some basic functionality for pooling C# objects.

## Foundation

The entire package is built on these 2 main interfaces:
- `IPool<T>` is a synchronous API, mostly for pooling C# objects.
- `IAsyncPool<T>` is an asynchronous API, mostly for pooling Unity objects.

## Basic pools

- `Pool<T>` and `AsyncPool<T>` implement the most generic functionality for pooling C# objects.

## Instantiator

Actually, `Pool<T, TInstantiator>` and `AsyncPool<T, T Instantiator>` are supertypes of `Pool<T>` and `AsyncPool<T>` respectively.

These supertypes allow customizing the way they create new instances of `T`.

By default, `Pool<T>` and `AsyncPool<T>` employ `System.Activator` to instantiating `T`.

### Example: Implementing a custom instantiator

```cs
public struct MyClassInstantiator : IInstantiable<MyClass>
{
    public MyClass Instantiate() => new MyClass();
}
...
var myPool = new Pool<MyClass, MyClassInstantiator>();
var myObj  = myPool.Rent();
```

## Shared Pools

`SharedPool.Of<T>` will return a shared instance (aka singleton) of any type that implements `IPool` and `IShareable` interfaces and have a default constructor.

```cs
var sharedMyPool   = SharedPool.Of< Pool<MyClass> >();
var sharedListPool = SharedPool.Of< ListPool<int> >();
```

The reason for this design is to not force singleton pattern onto any pool, and thus not complicate the pool inheritance tree.

On the other hand, the users should have a choice and be mindful about when and where to employ singletons into their own code.

## Disposable context

This is they way to automatically return instances to the pool at the end of their usage.

- Instead of renting an instance directly from the pool, we'll make a `DisposableContext` first.
- Use `using` when renting an instance so the disposing mechanism can be automated.

```cs
var pool           = SharedPool.Of< ListPool<int> >();
var disposablePool = pool.DisposableContext();
using var instance = disposablePool.Rent();

using (var otherInstance = disposablePool.Rent())
{
    // work with `otherInstance`

} // `otherInstance` will be returned to the pool automatically

// End of the Method
// `instance` will be returned to the pool automatically
```

# Collection Pools

- `System.Collections.Generic.Pooling`
- `Collections.Pooled.Generic.Pooling`

These 2 modules provide premade collection pools:

- `ListPool<T>`
- `HashSetPool<T>`
- `QueuePool<T>`
- `StackPool<T>`
- `DictionaryPool<TKey, TValue>`

```cs
var list  = SharedPool.Of< ListPool<int> >().Rent();
var myObj = SharedPool.Of< Pool<MyClass> >().Rent();

var dictPool = new DictionaryPool<int, string>();
var dict     = dictPool.Rent();
```

# Unity.Pooling

This module provides basic facility to pooling Unity objects, especially `GameObject` and `Component`:

- `UnityPool<T, TPrefab>` is the base for Unity object pools.
- `IPrefab` to implement custom Unity object instantiators.
- `IPrepooler<T, TPrefab, TPool>` to implement custom prepooling mechanism.
- `UnityPoolBehaviour<T, ...>` is the base for pool components attached on a `GameObject`.

## Pools

All the pools declared in this module are ready-to-use as they are.

- `UnityPool<T, TPrefab>`
- `GameObjectPool<TPrefab>`
- `GameObjectPool`
- `ComponentPool<T, TPrefab>`
- `ComponentPool<T>`

```cs
var goPool       = new GameObjectPool();
var colliderPool = new ComponentPool<BoxCollider>();
```

## Prefabs

Prefab is a way to change how pools would instantiate or release their objects.

- `UnityPrefab<T, TSource>`
- `GameObjectPrefab`
- `ComponentPrefab<T>`

If customization is needed, a subtype of `UnityPrefab<T, TSource>` must be implemented then passed to the generic pool that accept `TPrefab`.

```cs
public class CustomGameObjectPrefab : UnityPrefab<GameObject, GameObject>
{
    protected override async UniTask<GameObject> Instantiate(GameObject source, Transform parent)
    {
        // implement Instiatate method
    }

    public override void Release(GameObject instance)
    {
        // implement Release method
    }
}
...
var poolA = new GameObjectPool<CustomGameObjectPrefab>();
var poolB = new UnityPool<GameObject, CustomGameObjectPrefab>()
```

Alternately any type implements `IPrefab<T>` works the same way.

```cs
public class SimpleGameObjectPrefab : IPrefab<GameObject>
{
    public async UniTask<GameObject> Instantiate()
    {
        // implement Instiatate method
    }

    public void Release(GameObject instance)
    {
        // implement Release method
    }
}
...
var poolA = new GameObjectPool<SimpleGameObjectPrefab>();
var poolB = new UnityPool<GameObject, SimpleGameObjectPrefab>()
```

## Behaviours

These are wrappers of the pools, derived from `MonoBehaviour`:

- `PoolBehaviour<T, TPool>`
- `UnityPoolBehaviour<T, TPrefab, TPool>`
- `GameObjectPoolBehaviour`
- `ComponentPoolBehaviour<T>`

Only `GameObjectPoolBehaviour` is ready to be used.

Others require declaring non-generic subtypes:

```cs
public class BoxColliderPoolBehaviour
    : ComponentPoolBehaviour<BoxCollider>
{ }

public class SpritePoolBehaviour
    : UnityPoolBehaviour<SpriteRenderer, SpritePrefab, ComponentPool<SpriteRenderer>>
{ }
```

# Unity.Pooling.Addressables

This module offers 2 ways to work with Addressables:
- `Address*` requires a `string` address to load the asset
- `AssetRef*` requires an `AssetReference` to do that



# Unity.Pooling.Scriptables

# Unity.Pooling.Scriptables.Addressables

