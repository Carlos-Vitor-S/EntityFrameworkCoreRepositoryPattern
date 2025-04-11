using EntityFrameworkCore.Domain;

namespace RepositoryPatternEF.Interfaces.InterfacesBuilder {
    interface IClienteBuilder {
        IClienteBuilder DefinirId(int id);
        IClienteBuilder DefinirNome(string nome);
        IClienteBuilder DefinirTelefone(string telefone);
        IClienteBuilder DefinirEndereco(string cep, string estado, string cidade);
        Cliente Build();
    }
}
