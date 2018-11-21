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
            var query = @"INSERT INTO USUARIO(NOME, SEXO, CPF, EMAIL, DATANASCIMENTO) VALUES (@NOME, @SEXO, @CPF, @EMAIL, @DATANASCIMENTO)";

            await AddAsync(usuario, query);
        }

        public async Task<Usuario> GetAsync(int id)
        {
            var query = @"SELECT U.ID
                        ,U.NOME 
                        ,U.SEXO
                        ,U.CPF
                        ,U.EMAIL
                        ,U.DATANASCIMENTO 
                        FROM USUARIO AS U WITH (NOLOCK) WHERE U.ID = @ID";

            return await GetAsync(id, query);
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var query = @"SELECT U.ID, U.NOME, U.CPF, U.EMAIL FROM USUARIO AS U";

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

        public async Task UpdateAsync(Usuario usuario)
        {
            var query = @"UPDATE USUARIO 
                        SET NOME = @NOME 
                        ,CPF = @CPF 
                        ,EMAIL = @EMAIL
                        ,SEXO = @SEXO
                        ,DATANASCIMENTO = @DATANASCIMENTO WHERE ID = @ID";

            await UpdateAsync(usuario, query);
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            var query = @"DELETE FROM USUARIO WHERE ID = @ID";

            await DeleteAsync(usuario, query);
        }
    }
}