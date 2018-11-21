using CrudUsuario.Domain.Entities;
using CrudUsuario.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrudUsuario.WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService) 
            => _usuarioService = usuarioService;
        // GET: api/Usuarios
        public async Task<IHttpActionResult> Get()
        {
            var usuarios = await _usuarioService.GetAsync();

            return Ok(usuarios);
        }

        // GET: api/Usuarios/5
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            
            if(usuario == null) return NotFound();

            return Ok(usuario);
        }

        // POST: api/Usuarios
        public async Task<IHttpActionResult> PostAsync([FromBody]Usuario usuario)
        {
            await _usuarioService.CreateUserAsync(usuario);

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Usuario usuario)
        {
            var usuario_ = await _usuarioService.GetByIdAsync(id);

            if (usuario_ == null) return NotFound();

            usuario_.Nome = usuario.Nome;
            usuario_.CPF = usuario.CPF;
            usuario_.Email = usuario.Email;
            usuario_.DataNascimento = usuario.DataNascimento;
            usuario_.Sexo = usuario.Sexo;

            await _usuarioService.UpdateAsync(usuario_);

            return Ok();
        }

        // DELETE: api/Usuarios/5
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if (usuario == null) return NotFound();

            await _usuarioService.DeleteAsync(usuario);

            return Ok();
        }
    }
}
