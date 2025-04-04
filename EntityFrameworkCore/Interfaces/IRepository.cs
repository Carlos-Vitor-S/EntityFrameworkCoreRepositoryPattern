namespace RepositoryPatternEF.Interfaces {
    interface IRepository<T> where T : class {
        void Cadastrar(T elemento);
        void RemoverPorId(int id);
        void Atualizar(T elemento);
        List<T> GetAll();
    }
}
