using EntityFrameworkCore.Domain;

namespace RepositoryPatternEF.Interfaces {
    interface IClienteService {
        void Cadastrar(Cliente cliente);
        void Remover(Cliente cliente);
        void RemoverPorId(int id);
        void Atualizar(Cliente cliente);
        void Listar();
        Cliente GetPorId(int id);
        void SalvarAlteracoes();
    }
}
