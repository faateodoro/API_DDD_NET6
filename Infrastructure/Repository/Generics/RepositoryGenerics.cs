using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGenerics<T>, IDisposable where T : class
    {
        private DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(objeto); 
                await data.SaveChangesAsync();
            }
        }

        public async Task<IList<T>> Get()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task Update(T objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose#implement-the-dispose-pattern

        // To detect redundant calls
        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                _disposedValue = true;
            }
        }

        #endregion
    }
}
