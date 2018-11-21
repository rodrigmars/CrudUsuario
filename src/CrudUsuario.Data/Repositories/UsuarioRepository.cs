using CrudUsuario.Domain.DTO;
using CrudUsuario.Domain.Entities;
using CrudUsuario.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CrudUsuario.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IDbConnection connection) : base(connection) { }

        public async Task CreateAsync(Usuario usuario)
        {
            var query = @"INSERT INTO USUARIO(NOME, SEXO, CPF, EMAIL, DATANASCIMENTO) 
                        VALUES (@NOME, @SEXO, @CPF, @EMAIL, @DATANASCIMENTO)";

            await AddAsync(usuario, query);
        }

        public async Task<UsuarioDTO> GetAsync(int id)
        {
            var query = @"SELECT U.ID AS USUARIOID
                        ,U.NOME 
                        ,U.SEXO
                        ,U.CPF
                        ,U.EMAIL
                        ,U.DATANASCIMENTO 
                        FROM USUARIO AS U WITH (NOLOCK) WHERE U.ID = @ID";


            var usuario = await GetAsync(id, query);

            return new UsuarioDTO
            {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                CPF = usuario.CPF,
                Email = usuario.Email,
            };
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var query = @"SELECT U.ID AS USUARIOID, U.NOME, U.CPF, U.EMAIL FROM USUARIO AS U";

            var usuarios = await GetAllAsync(query);

            var lista = new List<UsuarioDTO>();

            foreach (var usuario in usuarios)
            {
                lista.Add(new UsuarioDTO
                {
                    UsuarioId = usuario.Id,
                    Nome = usuario.Nome,
                    CPF = usuario.CPF,
                    Email = usuario.Email,
                });
            }

            return lista;
        }
    }
}