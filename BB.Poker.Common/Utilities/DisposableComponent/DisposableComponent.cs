using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BB.Poker.Common
{
    /// <summary>Provides a thread-safe, abstract implementation of IDisposable.</summary>
    public abstract class DisposableComponent : IDisposable
    {
        /// <summary>Integer flag for whether Dispose has been called or not.  0 = false, 1 = true.</summary>
        protected volatile int _disposed;

        /// <summary>Disposes of the managed and unmanaged resources held by this Disposable.</summary>
        public void Dispose()
        {
            #pragma warning disable 420
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
            {
                GC.SuppressFinalize(this);
                DisposeUnmanagedResources();
                DisposeManagedResources();
            }
            #pragma warning restore 420
        }

        /// <summary>
        /// Disposes the managed resources held by this object.  You may clean up managed resources in this method, 
        /// such as instances of IDisposable.  This should never be called by your class except to call the base 
        /// (non-abstract) version of this method within the derived version. This method will only ever be called once.
        /// </summary>
        protected abstract void DisposeManagedResources();

        /// <summary>
        /// Disposes the unmanaged resources held by this object.  Do not clean up anything with a finalizer in 
        /// this method.  This should never be called by your class except to call the base (non-abstract) version 
        /// of this method within the derived version.  This method will only ever be called once.
        /// </summary>
        protected abstract void DisposeUnmanagedResources();

        /// <summary>Calls DisposeUnmanagedResources.  Managed resources cannot be cleaned up in finalizers.</summary>
        ~DisposableComponent() { DisposeUnmanagedResources(); }
    }
}
