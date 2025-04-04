using EntityFrameworkCore.Domain;
using RepositoryPatternEF.Interfaces;

namespace RepositoryPatternEF.Services {
    class ClienteService : IClienteService {

        private readonly IRepository<Cliente> _repositorioCliente;

        public ClienteService(IRepository<Cliente> repositorioCliente) {
            _repositorioCliente = repositorioCliente;
        }

        public void Atualizar(Cliente cliente) {
            _repositorioCliente.Atualizar(cliente);
        }

        public void CadastrarCliente(Cliente cliente) {

            _repositorioCliente.Cadastrar(cliente);

        }

        public void ListarClientes() {
            var todosClientes = _repositorioCliente.GetAll().OrderBy(c => c.Id);
            foreach (var cliente in todosClientes) {
                Console.Write($"ID: {cliente.Id} / Nome: {cliente.Nome} / Telefone: {cliente.Telefone}\n");
                Console.Write($"CEP: {cliente.CEP} / Estado: {cliente.Estado} / Cidade: {cliente.Cidade}\n");
                Console.WriteLine("______________________\n");
            }
        }

        public void RemoverClientePorId(int id) {
            _repositorioCliente.RemoverPorId(id);

        }
    }
}
