using Autofac;
using RepositoryPatternEF.Builders;
using RepositoryPatternEF.DataContext;
using RepositoryPatternEF.Interfaces;

namespace RepositoryPatternEF {
    class Program {
        public static void Main() {
            var injetorDependencias = InjetorDependencias.GetConfigs();

            using (var scope = injetorDependencias.BeginLifetimeScope()) {
                var dbContext = scope.Resolve<ApplicationContext>();
                var clienteService = scope.Resolve<IClienteService>();

                var clienteCadastrar = new ClienteBuilder()
                    .DefinirNome("Joao")
                    .DefinirTelefone("99999999")
                    .DefinirEndereco(cep: "499999", estado: "SE", cidade: "Itabaiana")
                    .Build();

                var clienteAtualizarOuRemover = new ClienteBuilder()
                    .DefinirId(81)
                    .DefinirNome("Marcos")
                    .DefinirTelefone("000000")
                    .DefinirEndereco(cep: "000000", estado: "SE", cidade: "Nossa Senhora da Glória")
                    .Build();

                clienteService.Cadastrar(clienteCadastrar);
                clienteService.RemoverPorId(81);
                clienteService.Remover(clienteAtualizarOuRemover);
                clienteService.Atualizar(clienteAtualizarOuRemover);
                clienteService.Listar();

            }
        }
    }
}
