using EntityFrameworkCore.Domain;
using RepositoryPatternEF.Interfaces;

namespace RepositoryPatternEF.Services {
    class ProdutoService : IProdutoService {

        private readonly IRepository<Produto> _repositorioProduto;

        public ProdutoService(IRepository<Produto> repositorioproduto) {
            _repositorioProduto = repositorioproduto;
        }

        public void Cadastrar(Produto produto) {
            _repositorioProduto.Cadastrar(produto);
            SalvarAlteracoes();
        }

        public void Atualizar(Produto produto) {
            _repositorioProduto.Atualizar(produto);
            SalvarAlteracoes();
        }

        public void Remover(Produto produto) {
            _repositorioProduto.Remover(produto);
            SalvarAlteracoes();
        }

        public void RemoverPorId(int id) {
            var produtoExistente = GetPorId(id);
            if (produtoExistente != null) {
                _repositorioProduto.Remover(GetPorId(id));
                SalvarAlteracoes();
            }
        }

        public void Listar() {
            var todosprodutos = _repositorioProduto.GetAllElements().OrderBy(c => c.Id);
            foreach (var produto in todosprodutos) {
                Console.Write($"ID: {produto.Id} / CodigoBarras: {produto.CodigoBarras} / Descricao: {produto.Descricao}\n");
                Console.Write($"Valor: {produto.Valor} / Tipo: {produto.TipoProduto} / Ativo: {produto.Ativo}\n");
                Console.WriteLine("______________________\n");
            }
        }

        public void SalvarAlteracoes() {
            _repositorioProduto.SalvarAlteracoes();
        }

        public Produto GetPorId(int id) {
            return _repositorioProduto.GetPorId(id);
        }
    }
}
