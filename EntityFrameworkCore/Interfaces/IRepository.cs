namespace RepositoryPatternEF.Interfaces {
    interface IRepository<T> where T : class {
        void Cadastrar(T elemento);
        void Remover(T elemento);
        void Atualizar(T elemento);
        List<T> GetAllElements();
        T GetPorId(int id);
        void SalvarAlteracoes();
    }
}
