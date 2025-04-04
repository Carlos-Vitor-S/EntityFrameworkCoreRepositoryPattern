using Autofac;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternEF.DataContext;
using RepositoryPatternEF.Interfaces;
using RepositoryPatternEF.Repository;
using RepositoryPatternEF.Services;

namespace RepositoryPatternEF {
    public static class InjetorDependencias {

        public static IContainer GetConfigs() {
            string connectionString = "Server=localhost;Port=5432;Database=vendasEntityFrameworkCore;User Id=postgres;Password=123;";

            var builder = new ContainerBuilder();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ClienteService>().As<IClienteService>().InstancePerLifetimeScope();
            builder.Register(ctx => {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                optionsBuilder.UseNpgsql(connectionString);
                return new ApplicationContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            var container = builder.Build();
            return container;
        }
    }

}
