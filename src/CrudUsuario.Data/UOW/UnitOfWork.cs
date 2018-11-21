using CrudUsuario.Data.Repositories;
using CrudUsuario.Domain.Interfaces;
using CrudUsuario.Domain.Interfaces.Repositories;
using System;
using System.Data;

namespace CrudUsuario.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbConnection _dbConnection { get; private set; }

        private IUsuarioRepository _usuarioRepository { get; set; }

        private bool _disposed;

        public UnitOfWork(IDbConnection dbConnection) => _dbConnection = dbConnection;

        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? new UsuarioRepository(_dbConnection);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void OpenAsync() => _dbConnection.OpenAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_dbConnection != null)
                    {
                        _dbConnection.Dispose();
                        _dbConnection = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}
