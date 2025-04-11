using EntityFrameworkCore.Domain;

namespace RepositoryPatternEF.Interfaces {
    interface IProdutoService {
        void Cadastrar(Produto produto);
        void Remover(Produto produto);
        void RemoverPorId(int id);
        void Atualizar(Produto produto);
        void Listar();
        Produto GetPorId(int id);
        void SalvarAlteracoes();
    }
}
