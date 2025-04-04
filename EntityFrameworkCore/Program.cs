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
              clienteService.CadastrarCliente(new Cliente {
                    Nome = "Maria oliveira",
                    CEP = "49680000",
                    Cidade = "Nossa Senhora da Glória",
                    Estado = "SE",
                    Telefone = "12345678900"
                });

                clienteService.RemoverClientePorId(id: 1);

                clienteService.Atualizar(new Cliente {
                    Id = 4,
                    Nome = "Maria oliveira",
                    CEP = "49680000",
                    Cidade = "Nossa Senhora da Glória",
                    Estado = "SE",
                    Telefone = "12345678900"
                });
             
                clienteService.ListarClientes();

            }

        }

    }
}
