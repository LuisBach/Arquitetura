using System;
using TudoFilmes.Authorization.Infra.Data.Context;
using TudoFilmes.Authorization.Infra.Data.Interfaces;

namespace TudoFilmes.Authorization.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TudoFilmesContext _context;
        private bool _disposed;

        public UnitOfWork(TudoFilmesContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
