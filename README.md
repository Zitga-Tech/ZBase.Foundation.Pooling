# Unity.Pooling

## Dependencies

- [com.cysharp.unitask](https://github.com/Cysharp/UniTask)
- [com.laicasaane.collections.pooled](https://github.com/laicasaane/Collections.Pooled)

## Addressables support

The related modules will be enabled automatically when the [com.unity.addressables](https://docs.unity3d.com/Packages/com.unity.addressables@1.19/manual/index.html) package is installed.

## Thread-safety disclaimer

:warning: This package does NOT factor thread-safety into its design.

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

`SharedPool.Of<T>` will return a shared instance (aka singleton) of any type that implements `IPool` interface and have a default constructor.

```cs
var sharedMyPool   = SharedPool.Of< Pool<MyClass> >();
var sharedListPool = SharedPool.Of< ListPool<int> >();
```

The reason for this design is to not force singleton pattern onto any pool, and thus not complicate the pool inheritance tree.

On the other hand, the users should have a choice and be mindful about when and where to employ singletons into their own code.

## Disposable contexts

-

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
- `UnityPoolBehaviour<T, ...>` is the base for components to be attached on a `GameObject`.
- `IPrepooler<...>` to implement custom prepooling mechanism.

## Pools

All the pools declared in this module are ready-to-use as they are.

```cs
var goPool       = new GameObjectPool();
var colliderPool = new ComponentPool<BoxCollider>();
...
var goPoolCustom = new GameObjectPool<MyGameObjectPrefab>();
...
var simpleGOPool = new UnityPool<GameObject, MyGameObjectPrefab>()
```

## Behaviours

Only `GameObjectPoolBehaviour` is ready to add onto a `GameObject`.

Other behaviours require declaring non-generic subtypes before using.

```cs
public class BoxColliderPoolBehaviour : ComponentPoolBehaviour<BoxCollider> { }
```

# Unity.Pooling.Addressables

This module offers 2 ways to integrate Addressables:
- `AssetRef*` requires `AssetReference` to refer to the asset
- `AssetName*` requires a `string` to do that instead



# Unity.Pooling.Scriptables

# Unity.Pooling.Scriptables.Addressables

