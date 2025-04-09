using Autofac;
using EntityFrameworkCore.Domain;
using RepositoryPatternEF.DataContext;
using RepositoryPatternEF.Interfaces;

namespace RepositoryPatternEF {
    class Program {
        public static void Main() {
            var injetorDependencias = InjetorDependencias.GetConfigs();

            using (var scope = injetorDependencias.BeginLifetimeScope()) {
                var dbContext = scope.Resolve<ApplicationContext>();
                var clienteService = scope.Resolve<IClienteService>();

                //CRUD
                clienteService.Cadastrar(new Cliente {
                    Nome = "Joel jo oliveira",
                    CEP = "49680000",
                    Cidade = "Nossa Senhora da Glória",
                    Estado = "SE",
                    Telefone = "12345678900"
                });

                clienteService.RemoverPorId(id: 73);

                clienteService.Atualizar(cliente: new Cliente {
                    Id = 7,
                    Nome = "Flavia Silva Santos Oliveira",
                    CEP = "89680000",
                    Cidade = "Cidade Y",
                    Estado = "AL",
                    Telefone = "92345678900"
                });

                clienteService.Listar();

            }
        }
    }
}
