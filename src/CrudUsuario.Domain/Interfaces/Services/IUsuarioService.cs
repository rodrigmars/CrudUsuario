using CrudUsuario.Domain.DTO;
using CrudUsuario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudUsuario.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task CreateUserAsync(Usuario usuario);

        Task<Usuario> GetByIdAsync(int id);

        Task<IEnumerable<UsuarioDTO>> GetAsync();

        Task UpdateAsync(Usuario usuario);

        Task DeleteAsync(Usuario usuario);
    }
}
