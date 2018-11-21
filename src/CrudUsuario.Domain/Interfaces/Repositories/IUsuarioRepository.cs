using CrudUsuario.Domain.DTO;
using CrudUsuario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudUsuario.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task CreateAsync(Usuario usuario);

        Task<Usuario> GetAsync(int id);

        Task<IEnumerable<UsuarioDTO>> GetAllAsync();

        Task UpdateAsync(Usuario usuario);

        Task DeleteAsync(Usuario usuario);
    }
}
