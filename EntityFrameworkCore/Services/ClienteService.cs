using EntityFrameworkCore.Domain;
using RepositoryPatternEF.Interfaces;

namespace RepositoryPatternEF.Services {
    class ClienteService : IClienteService {

        private readonly IRepository<Cliente> _repositorioCliente;

        public ClienteService(IRepository<Cliente> repositorioCliente) {
            _repositorioCliente = repositorioCliente;
        }

        public void Cadastrar(Cliente cliente) {
            _repositorioCliente.Cadastrar(cliente);
            SalvarAlteracoes();
        }

        public void Atualizar(Cliente cliente) {
            _repositorioCliente.Atualizar(cliente);
            SalvarAlteracoes();
        }

        public void Remover(Cliente cliente) {
            _repositorioCliente.Remover(cliente);
            SalvarAlteracoes();
        }

        public void RemoverPorId(int id) {
            var clienteExistente = GetPorId(id);
            if (clienteExistente != null) {
                _repositorioCliente.Remover(GetPorId(id));
                SalvarAlteracoes();
            }
        }

        public void Listar() {
            var todosClientes = _repositorioCliente.GetAllElements().OrderBy(c => c.Id);
            foreach (var cliente in todosClientes) {
                Console.Write($"ID: {cliente.Id} / Nome: {cliente.Nome} / Telefone: {cliente.Telefone}\n");
                Console.Write($"CEP: {cliente.CEP} / Estado: {cliente.Estado} / Cidade: {cliente.Cidade}\n");
                Console.WriteLine("______________________\n");
            }
        }

        public void SalvarAlteracoes() {
            _repositorioCliente.SalvarAlteracoes();
        }

        public Cliente GetPorId(int id) {
            return _repositorioCliente.GetPorId(id);
        }
    }
}
