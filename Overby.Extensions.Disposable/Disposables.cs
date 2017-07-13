using System;
using System.Collections.Generic;

namespace Overby.Extensions.Disposable
{
    /// <summary>
    /// Accumulate disposable objects and dispose all at once.
    /// </summary>
    public class Disposables : IDisposable
    {
        private Queue<IDisposable> _q = new Queue<IDisposable>();
        private readonly object _mutex = new object();

        public Disposables(IEnumerable<IDisposable> disposables)
        {
            foreach (var item in disposables ?? throw new ArgumentNullException(nameof(disposables)))
                _q.Enqueue(item);
        }

        public Disposables() { }

        /// <summary>
        /// Register an object for disposal.
        /// </summary>
        public T Register<T>(T value) where T : IDisposable
        {
            lock (_mutex)
                _q.Enqueue(value);

            return value;
        }

        /// <summary>
        /// Dispose all accumulated disposable objects.
        /// </summary>
        public void Dispose()
        {
            lock (_mutex)
                dispose();

            void dispose()
            {
                if (_q.Count > 0)
                {
                    using (_q.Dequeue())
                        dispose();
                }
            }
        }
    }
}
