using CrudUsuario.Domain.DTO;
using System.Threading.Tasks;

namespace CrudUsuario.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetByIdAsync(int id);
    }
}
