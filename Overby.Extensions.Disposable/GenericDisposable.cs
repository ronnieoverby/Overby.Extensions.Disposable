using System;

namespace Overby.Extensions.Disposable
{
    /// <summary>
    /// Creates an IDisposable instance that will invoke
    /// the supplied action when Dispose is invoked.
    /// </summary>
    public class GenericDisposable : IDisposable
    {
        private readonly Action _dispose;

        public GenericDisposable(Action onDispose)
        {
            _dispose = onDispose ?? throw new ArgumentNullException(nameof(onDispose));
        }

        public void Dispose() => _dispose?.Invoke();
    }


    /// <summary>
    /// Creates an IDisposable instance that will invoke
    /// the supplied action when Dispose is invoked.
    /// </summary>
    public class GenericDisposable<T> : GenericDisposable
    {
        public T Value { get; }

        public GenericDisposable(T value, Action<T> onDispose) : base(() => onDispose(value))
        {
            Value = value;
        }

        public static implicit operator T(GenericDisposable<T> gd) => gd.Value;
    }
}
