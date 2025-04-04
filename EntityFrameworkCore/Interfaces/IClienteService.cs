using EntityFrameworkCore.Domain;

namespace RepositoryPatternEF.Interfaces {
    interface IClienteService {
        void CadastrarCliente(Cliente cliente);
        void RemoverClientePorId(int id);
        void Atualizar(Cliente cliente);
        void ListarClientes();
    }
}
