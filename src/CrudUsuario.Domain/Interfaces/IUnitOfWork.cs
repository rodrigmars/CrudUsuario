using CrudUsuario.Domain.Interfaces.Repositories;
using System;

namespace CrudUsuario.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }

        void OpenAsync();
    }
}