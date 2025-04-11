using EntityFrameworkCore.Domain;
using RepositoryPatternEF.Interfaces.InterfacesBuilder;

namespace RepositoryPatternEF.Builders {
    class ClienteBuilder : IClienteBuilder {
        private Cliente _cliente;

        public ClienteBuilder() {
            _cliente = new Cliente();
        }
        public IClienteBuilder DefinirNome(string nome) {
            _cliente.Nome = nome;
            return this;
        }

        public IClienteBuilder DefinirId(int id) {
            _cliente.Id = id;
            return this;
        }

        public IClienteBuilder DefinirEndereco(string cep, string estado, string cidade) {
            _cliente.CEP = cep;
            _cliente.Estado = estado;
            _cliente.Cidade = cidade;
            return this;
        }

        public IClienteBuilder DefinirTelefone(string telefone) {
            _cliente.Telefone = telefone;
            return this;
        }

        public Cliente Build() {
            return _cliente;
        }


    }
}
