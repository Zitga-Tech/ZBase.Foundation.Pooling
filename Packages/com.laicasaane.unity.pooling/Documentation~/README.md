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

This module builds a foundation for this entire package. There are also some basic functionality for pooling C# objects.

The foundation provides 2 kinds of pool: `IPool<T>` and `IAsyncPool<T>`.
- To pool C# objects, `IPool<T>` will be mostly used. Unless there is a need to fetch objects from some asynchronous contexts.
- On the other hand, `IAsyncPool<T>` will be used to pool Unity objects.



# System.Collections.Generic.Pooling

# Collections.Pooled.Generic.Pooling

# Unity.Pooling

# Unity.Pooling.Addressables

# Unity.Pooling.Scriptables

# Unity.Pooling.Scriptables.Addressables

