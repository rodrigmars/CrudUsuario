using CrudUsuario.Domain.DTO;
using CrudUsuario.Domain.Entities;
using CrudUsuario.Domain.Interfaces;
using CrudUsuario.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudUsuario.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task CreateUserAsync(Usuario usuario)
            => await _unitOfWork.UsuarioRepository.CreateAsync(usuario);

        public async Task<Usuario> GetByIdAsync(int id)
            => await _unitOfWork.UsuarioRepository.GetAsync(id);

        public async Task<IEnumerable<UsuarioDTO>> GetAsync()
            => await _unitOfWork.UsuarioRepository.GetAllAsync();

        public async Task UpdateAsync(Usuario usuario)
            => await _unitOfWork.UsuarioRepository.UpdateAsync(usuario);

        public async Task DeleteAsync(Usuario usuario)
            => await _unitOfWork.UsuarioRepository.DeleteAsync(usuario);
    }
}