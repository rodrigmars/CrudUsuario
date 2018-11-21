using CrudUsuario.Domain.Interfaces;

namespace CrudUsuario.Data.DBContext
{
    public class DbContextOptions: IConnectionstring
    {

        public DbContextOptions(string connectionstring) => Connectionstring = connectionstring;

        public string Connectionstring { get; }
    }
}
