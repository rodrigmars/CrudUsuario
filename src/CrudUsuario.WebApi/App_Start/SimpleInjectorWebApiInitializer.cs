[assembly: WebActivator.PostApplicationStartMethod(typeof(CrudUsuario.WebApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace CrudUsuario.WebApi.App_Start
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Http;
    using CrudUsuario.Data.Repositories;
    using CrudUsuario.Data.UOW;
    using CrudUsuario.Domain.Interfaces;
    using CrudUsuario.Domain.Interfaces.Repositories;
    using CrudUsuario.Domain.Interfaces.Services;
    using CrudUsuario.Domain.Services;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            var connection = ConfigurationManager.ConnectionStrings["CrudUsuarioDBString"];

  

            container.Register<IDbConnection>(() => new SqlConnection(connection.ToString()),
                Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register(typeof(IRepository<>), typeof(Repository<>).Assembly, Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
        }
    }
}