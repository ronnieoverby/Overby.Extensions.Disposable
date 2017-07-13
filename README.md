# Overby.Extensions.Disposable
Essential additions to IDisposable.

## Install

```
PM> Install-Package Overby.Extensions.Disposable
```


## Cool Stuff This Thing Does
- Turn anything into an `IDisposable` (`GenericDisposable<T>` class and `.AsDisposable()` extension method)
- Accumulate many disposables (`Disposables` class)
- Dispose a sequence of `IDisposable`s (`.DisposeMany()` extension method)
