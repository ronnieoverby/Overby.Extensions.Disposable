using System;
using System.Collections.Generic;

namespace Overby.Extensions.Disposable
{
    public static class Extensions
    {
        /// <summary>
        /// Returns a disposable object that will invoke the action
        /// when Dispose() is invoked.
        /// </summary>
        public static GenericDisposable<T> AsDisposable<T>(this T obj, Action<T> onDispose) =>
            new GenericDisposable<T>(obj, onDispose);

        /// <summary>
        /// Registers an object with the <see cref="Disposables" /> instance with custom disposal logic.        
        /// </summary>
        public static T DisposeWith<T>(this T value, Disposables disposables, Action<T> onDispose) =>
            disposables.Register(value.AsDisposable(onDispose));

        /// <summary>
        /// Registers an IDisposable with the <see cref="Disposables"/> instance.
        /// </summary>
        public static T DisposeWith<T>(this T value, Disposables disposables) where T : IDisposable =>
            disposables.Register(value);

        /// <summary>
        /// Disposes all if the supplied IDisposable instances.
        /// </summary>
        public static void DisposeMany(this IEnumerable<IDisposable> disposables) =>
            new Disposables(disposables).Dispose();
    }
}
