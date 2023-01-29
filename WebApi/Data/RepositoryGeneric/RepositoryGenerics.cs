using Business.Interfaces;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Data.RepositoryGeneric
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<AppDBContext> _context;
        public RepositoryGenerics()
        {
            _context = new DbContextOptions<AppDBContext>();
        }

        public async Task Create(T entity)
        {
            using (var context = new AppDBContext(_context))
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(T entity)
        {
            using (var context = new AppDBContext(_context))
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> Get()
        {
            using (var context = new AppDBContext(_context))
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var context = new AppDBContext(_context))
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task Update(T entity)
        {
            using (var context = new AppDBContext(_context))
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
