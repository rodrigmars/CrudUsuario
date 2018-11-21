using CrudUsuario.Domain.DTO;
using CrudUsuario.Domain.Entities;
using CrudUsuario.Domain.Interfaces;
using CrudUsuario.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace CrudUsuario.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task CreateUserAsync(Usuario usuario)
        {
            _unitOfWork.OpenAsync();

            await _unitOfWork.UsuarioRepository.CreateAsync(usuario);
        }

        public async Task<UsuarioDTO> GetByIdAsync(int id)
        {
            _unitOfWork.OpenAsync();

            return await _unitOfWork.UsuarioRepository.GetAsync(id);
        }
    }
}