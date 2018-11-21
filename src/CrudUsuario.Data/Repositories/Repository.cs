using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CrudUsuario.Domain.Interfaces.Repositories;
using Dapper;

namespace CrudUsuario.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbConnection _connection;

        public Repository(IDbConnection connection)
            => _connection = connection;

        public async Task AddAsync(T entity, string query)
            => await _connection.ExecuteAsync(query, entity);

        public async Task<T> GetAsync(int id, string query)
            => await _connection.QueryFirstOrDefaultAsync<T>(query, new { id });

        public async Task<IEnumerable<T>> GetAllAsync(string query)
            => await _connection.QueryAsync<T>(query);

        public async Task UpdateAsync(T entity, string query)
            => await _connection.ExecuteAsync(query, entity);

        public async Task DeleteAsync(T entity, string query)
             => await _connection.ExecuteAsync(query, entity);
    }
}