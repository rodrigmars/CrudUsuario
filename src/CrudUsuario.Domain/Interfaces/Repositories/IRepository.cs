using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudUsuario.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity, string query);

        Task<IEnumerable<T>> GetAllAsync(string query);

        Task<T> GetAsync(int id, string query);

        Task DeleteAsync(T entity, string query);

        Task UpdateAsync(T entity, string query);
    }
}
