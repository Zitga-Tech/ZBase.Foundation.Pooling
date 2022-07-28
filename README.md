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

## Shared pools

`SharedPool.Of<T>` will return a shared instance (aka singleton) of any type that implements `IPool` interface and have a default constructor.

```cs
var sharedMyPool   = SharedPool.Of< Pool<MyClass> >();
var sharedListPool = SharedPool.Of< ListPool<int> >();
```

The reason it is designed this way is to uncouple the singleton pattern from type definition, and to help simplify type reuse.

# System.Collections.Generic.Pooling

# Collections.Pooled.Generic.Pooling

# Unity.Pooling

# Unity.Pooling.Addressables

# Unity.Pooling.Scriptables

# Unity.Pooling.Scriptables.Addressables

